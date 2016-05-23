using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Inventor;
using Application = Inventor.Application;

namespace Val
{
    /// <summary>
    /// Inventor API.
    /// </summary>
    public class InventorApi
    {
        #region Fields

        /// <summary>
        /// Ссылка на приложение Инвентора.
        /// </summary>
        private Application _invApp;

        /// <summary>
        /// Документ в приложении.
        /// </summary>
        private PartDocument _partDoc;

        /// <summary>
        /// Описание документа.
        /// </summary>
        private PartComponentDefinition _partDef;

        /// <summary>
        /// Геометрия приложения.
        /// </summary>
        private TransientGeometry _transGeometry;

       /// <summary>
        /// Текущий скетч.
        /// </summary>
        private PlanarSketch _currentSketch;
        
        /// <summary>
        /// Коллекция граней.
        /// </summary>
        private EdgeCollection _edgeCol;

        /// <summary>
        /// Индекс для масштабирования размеров.
        /// </summary>
        private const double Index = 10.0;
        
        #endregion

        #region Methods

        /// <summary>
        /// Инициализировать Инвентор и подготовить переменные.
        /// </summary>
        public InventorApi()
        {
            try
            {
                _invApp = (Application)Marshal.GetActiveObject("Inventor.Application");
            }
            catch (Exception)
            {
                try
                {
                    Type invAppType = Type.GetTypeFromProgID("Inventor.Application");

                    _invApp = (Application)Activator.CreateInstance(invAppType);
                    _invApp.Visible = true;

                    //Note: if the Inventor session is left running after this
                    //form is closed, there will still an be and Inventor.exe 
                    //running. We will use this Boolean to test in Form1.Designer.cs 
                    //in the dispose method whether or not the Inventor App should
                    //be shut down when the form is closed.

                }
                catch (Exception)
                {
                    //MessageBox.Show(ex2.ToString());
                    MessageBox.Show(@"Не удалось запустить инвентор.");
                }
            }

            // В открытом приложении создаем документ.
            _partDoc = (PartDocument)_invApp.Documents.Add 
                (DocumentTypeEnum.kPartDocumentObject,
                    _invApp.FileManager.GetTemplateFile
                        (DocumentTypeEnum.kPartDocumentObject,
                            SystemOfMeasureEnum.kMetricSystemOfMeasure));
          
            _partDef = _partDoc.ComponentDefinition;
            _transGeometry = _invApp.TransientGeometry; 
        }

        /// <summary>
        /// Создание плоскости переносом плоскостей ZY, ZX, XY.
        /// </summary>
        /// <param name="n">Номер плоскости: 1 - ZY, 2 - ZX, 3 - XY</param>
        /// <param name="offset">Относительное смещение плоскости</param>
        public void MakeNewWorkingPlane(int n, double offset)
        {
            var mainPlane = _partDef.WorkPlanes[n];
            var offsetPlane = _partDef.WorkPlanes.AddByPlaneAndOffset(mainPlane, offset / Index);
            _currentSketch = _partDef.Sketches.Add(offsetPlane);
        }

        /// <summary>
        /// Рисует прямоугольник по двум точкам.
        /// </summary>
        /// <param name="pointOneX">Левая верхняя координата X</param>
        /// <param name="pointOneY">Левая верхняя координата Y</param>
        /// <param name="pointTwoX">Правая нижняя координата X</param>
        /// <param name="pointTwoY">Правая нижняя координата Y</param>
        public void DrawRectangle(double pointOneX, double pointOneY, double pointTwoX, double pointTwoY)
        {
            pointOneX /= Index;
            pointOneY /= Index;
            pointTwoX /= Index;
            pointTwoY /= Index;
            var cornerPointOne = _transGeometry.CreatePoint2d(pointOneX, pointOneY);
            var cornerPointTwo = _transGeometry.CreatePoint2d(pointTwoX, pointTwoY);
            _currentSketch.SketchLines.AddAsTwoPointRectangle(cornerPointOne, cornerPointTwo);
        }

       /// <summary>
       /// Выдавливание текста.
       /// </summary>
       /// <param name="caption">Текст</param>
       /// <param name="startX">Начальная координата Х</param>
       /// <param name="startY">Начальная координата У</param>
       /// <param name="startZ">Относительное смещение поскости</param>
        public void DrawText(string caption, double startX, double startY, double startZ, OrientationParameterType orientationParameterType)
        {
            MakeNewWorkingPlane(2, startZ);
            var text = _currentSketch.TextBoxes.AddFitted(_transGeometry.CreatePoint2d(startX, startY),
                "<StyleOverride FontSize='1.0' Bold='True'>" + caption + "</StyleOverride>");
            text.HorizontalJustification = HorizontalTextAlignmentEnum.kAlignTextCenter;
            text.VerticalJustification = VerticalTextAlignmentEnum.kAlignTextMiddle;

            var textBox = _currentSketch.TextBoxes[1];
            textBox.ShowBoundaries = true;

            var collection = _invApp.TransientObjects.CreateObjectCollection();
            collection.Add(textBox);
            var pointRotation = _transGeometry.CreatePoint2d(startX, startY);

          //  OrientationParameterType type = OrientationParameterType;

            if (orientationParameterType == OrientationParameterType.Horizontal)
            {
                _currentSketch.RotateSketchObjects(collection, pointRotation, Math.PI/2.0);
            }
            else
            {
                _currentSketch.RotateSketchObjects(collection, pointRotation, (Math.PI/2.0)*90);
            }
            Extrude(Index);
        }
        /* неудачные попытки поменять угол наклона плоскости
        public void RotateWorkingPlane()
        {
            //var collection = _invApp.TransientObjects.CreateObjectCollection();
            //collection.Add(_currentSketch);
            //_currentSketch.RotateSketchObjects(, , (Math.PI/2.0)*45);

            _partDef.WorkPlanes.
        }*/

        /// <summary>
        /// Построение фаски.
        /// </summary>
        /// <param name="valueChamfer"> Дистанция выдвливания фаски</param>
        /// <param name="numberOfStage">Номер ступени, на которой выдавливается фаска</param>
        public void DrawChamfer(double valueChamfer, NumberOfStage numberOfStage)
        {
            Face selectedFace = null;
            while (selectedFace == null)
            {
                try
                {
                    selectedFace = _invApp.ActiveDocument.SelectSet[1];
                }
                catch
                {
                     MessageBox.Show("Выберите " + (int) (numberOfStage + 1) + 
                         " грань, на которой следует посторить фаску! "  ,  "Информация", 
                         MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 
                         MessageBoxOptions.ServiceNotification);
                }
            }
           
            _edgeCol = _invApp.TransientObjects.CreateEdgeCollection();
           _edgeCol.Add(selectedFace.Edges[1]);
           _edgeCol.Add(numberOfStage != NumberOfStage.Stage5
                ? selectedFace.Edges[1] 
                : selectedFace.Edges[2]);
            _partDef.Features.ChamferFeatures.AddUsingDistanceAndAngle(_edgeCol, selectedFace, valueChamfer.ToString(), 0.5233);
        }

        /// <summary>
        /// Рисует круг.
        /// </summary>
        /// <param name="centerPointX">Координата X центра круга</param>
        /// <param name="centerPointY">Координата Y центра круга</param>
        /// <param name="diameter">Диаметр круга</param>
        public void DrawCircle(double centerPointX, double centerPointY, double diameter)
        {
            centerPointX /= Index;
            centerPointY /= Index;
            diameter /= Index;
            _currentSketch.SketchCircles.AddByCenterRadius(_transGeometry.CreatePoint2d(centerPointX, centerPointY), 
                0.5 * diameter);
        }

        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="distance">Длинна выдавливания</param>
        /// <param name="extrudeDirection">Направление выдавливания</param>
        public void Extrude(double distance, PartFeatureExtentDirectionEnum extrudeDirection = PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        {
            var extrudeDef = _partDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(_currentSketch.Profiles.AddForSolid(), 
                PartFeatureOperationEnum.kJoinOperation);
            extrudeDef.SetDistanceExtent(distance / Index, extrudeDirection);
            _partDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }

        /// <summary>
        /// Выдавить с вычитанием.
        /// </summary>
        /// <param name="diameter">Диаметр круга</param>
        /// <param name="distance">Дистанция выдавливания</param>
        /// <param name="centerPointX">X координата центра</param>
        /// <param name="centerPointY">Y координата центра</param>
        public void CutExtrudeCircle(double centerPointX, double centerPointY, double diameter, double distance)
        {
            DrawCircle(centerPointX, centerPointY, diameter);
            var extrudeDef = _partDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(_currentSketch.Profiles.AddForSolid(), 
                PartFeatureOperationEnum.kCutOperation);
            extrudeDef.SetDistanceExtent(distance / Index, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
           _partDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }

        /// <summary>
        /// Выдавить с вычитанием прямоугольник.
        /// </summary>
        /// <param name="pointOneX">Начальная координата Х</param>
        /// <param name="pointOneY">Начальная координата У</param>
        /// <param name="pointTwoX">Конечная координата Х</param>
        /// <param name="pointTwoY">Конечная координата У</param>
        /// <param name="distance">Дистанция выдавливания</param>
        public void CutExtrudeRectangle(double pointOneX, double pointOneY, double pointTwoX, double pointTwoY, double distance)
        {
            pointOneX /= Index;
            pointOneY /= Index;
            pointTwoX /= Index;
            pointTwoY /= Index;
            var cornerPointOne = _transGeometry.CreatePoint2d(pointOneX, pointOneY);
            var cornerPointTwo = _transGeometry.CreatePoint2d(pointTwoX, pointTwoY);
            _currentSketch.SketchLines.AddAsTwoPointRectangle(cornerPointOne, cornerPointTwo);
            var extrudeDef = _partDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(_currentSketch.Profiles.AddForSolid(), 
                PartFeatureOperationEnum.kCutOperation);
            extrudeDef.SetDistanceExtent(distance / Index, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            _partDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }

        /// <summary>
        /// Выполняет полное вращение замкнутого скетча вокруг оси.
        /// </summary>
        /// <param name="startPointX">Координата X начала оси вращения</param>
        /// <param name="startPointY">Координата Y начала оси вращения</param>
        /// <param name="endPointX">Координата X конца оси вращения</param>
        /// <param name="endPointY">Координата Y конца оси вращения</param>
        public void RevolveFull(double startPointX, double startPointY, double endPointX, double endPointY)
        {
            var startPoint = _transGeometry.CreatePoint2d(startPointX, startPointY);
            var endPoint = _transGeometry.CreatePoint2d(endPointX, endPointY);
            var line = _currentSketch.SketchLines.AddByTwoPoints(startPoint, endPoint);
            var profile = _currentSketch.Profiles.AddForSolid();
           _partDef.Features.RevolveFeatures.AddFull(profile, line, PartFeatureOperationEnum.kJoinOperation);
        }

        /// <summary>
        /// Построить линию.
        /// </summary>
        /// <param name="startPointX">Начальная координата X</param>
        /// <param name="startPointY">Начальная координата Y</param>
        /// <param name="endPointX">Конечная координата X</param>
        /// <param name="endPointY">Конечная координата Y</param>
        public void DrawLine(double startPointX, double startPointY, double endPointX, double endPointY)
        {
            startPointX /= Index;
            startPointY /= Index;
            endPointX /= Index;
            endPointY /= Index;
            var startPoint = _transGeometry.CreatePoint2d(startPointX, startPointY);
            var endPoint = _transGeometry.CreatePoint2d(endPointX, endPointY);
            _currentSketch.SketchLines.AddByTwoPoints(startPoint, endPoint);
        }

        /// <summary>
        /// Продолжает линию с последней точки.
        /// </summary>
        /// <param name="endPointX">Координата X конца линии</param>
        /// <param name="endPointY">Координата Y конца линии</param>
        public void DrawLine(double endPointX, double endPointY)
        {
            endPointX /= Index;
            endPointY /= Index;
            var endPoint = _transGeometry.CreatePoint2d(endPointX, endPointY);
            _currentSketch.SketchLines.AddByTwoPoints(_currentSketch.SketchLines[_currentSketch.SketchLines.Count].EndSketchPoint, endPoint);
        }


        /// <summary>
        /// Метод соединяет первую и последнюю точки.
        /// </summary>
        public void CloseShape()
        {
            _currentSketch.SketchLines.AddByTwoPoints(
                _currentSketch.SketchLines[_currentSketch.SketchLines.Count].EndSketchPoint,
                _currentSketch.SketchLines[1].StartSketchPoint);
        }

        #endregion
    }
}
