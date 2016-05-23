using System;
using System.Collections.Generic;
using Inventor;
using System.Diagnostics;

namespace Val
{
    /// <summary>
    /// Класс инкапсулирует модель, вызывает построение модели.
    /// </summary>
    public class ValModel
    {
        #region Fields

        /// <summary>
        /// Параметры модели.
        /// </summary>
        private readonly ValProperties _valProperties;

        /// <summary>
        /// САПР API.
        /// </summary>
        private readonly InventorApi _api;

        /// <summary>
        /// Ориентация текста.
        /// </summary>
        private OrientationParameterType _orientationParameterType;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор с входными параметрами модели.
        /// </summary>
        /// <param name="valProperties">Параметры модели</param>
        /// <param name="inventorApi"></param>
        public ValModel(ValProperties valProperties, InventorApi inventorApi)
        {
            _valProperties = valProperties;
            _api = inventorApi;
        }

        /// <summary>
        /// Функция строит модель.
        /// </summary>
        public void Build()
        {
            BuildShaft();
        }

        /// <summary>
        /// Функция строит основу пятиступенчатого вала.
        /// </summary>
        private void BuildShaft()
        {
            var shaftDiameter1Stage = _valProperties.GetParameter(ParameterType.ShaftDiameter1Stage).Value;
            var shaftDiameter2Stage = _valProperties.GetParameter(ParameterType.ShaftDiameter2Stage).Value;
            var shaftDiameter3Stage = _valProperties.GetParameter(ParameterType.ShaftDiameter3Stage).Value;
            var shaftDiameter4Stage = _valProperties.GetParameter(ParameterType.ShaftDiameter4Stage).Value;
            var shaftDiameter5Stage = _valProperties.GetParameter(ParameterType.ShaftDiameter5Stage).Value;
            var shaftLength1Stage = _valProperties.GetParameter(ParameterType.ShaftLength1Stage).Value;
            var shaftLength2Stage = _valProperties.GetParameter(ParameterType.ShaftLength2Stage).Value;
            var shaftLength3Stage = _valProperties.GetParameter(ParameterType.ShaftLength3Stage).Value;
            var shaftLength4Stage = _valProperties.GetParameter(ParameterType.ShaftLength4Stage).Value;
            var shaftLength5Stage = _valProperties.GetParameter(ParameterType.ShaftLength5Stage).Value;
            var groove = _valProperties.GetParameter(ParameterType.Groove).Value;

            var lengthKeyway1Stage = _valProperties.GetParameter(ParameterType.LengthKeyway1Stage).Value;
            var widthKeyway1Stage = _valProperties.GetParameter(ParameterType.WidthKeyway1Stage).Value;
            var heightKeyway1Stage = _valProperties.GetParameter(ParameterType.HeightKeyway1Stage).Value;

            var lengthKeyway3Stage = _valProperties.GetParameter(ParameterType.LengthKeyway3Stage).Value;
            var widthKeyway3Stage = _valProperties.GetParameter(ParameterType.WidthKeyway3Stage).Value;
            var heightKeyway3Stage = _valProperties.GetParameter(ParameterType.HeightKeyway3Stage).Value;


            var stages = new List<Tuple<double, double, double>>
            {
                new Tuple<double, double, double>(-shaftLength5Stage/2, shaftDiameter5Stage, shaftLength5Stage - groove),
                new Tuple<double, double, double>(shaftLength5Stage/2 - groove, shaftDiameter5Stage - groove, groove),
                new Tuple<double, double, double>(shaftLength5Stage/2, shaftDiameter4Stage, shaftLength4Stage),
                new Tuple<double, double, double>((shaftLength4Stage + shaftLength5Stage/2), shaftDiameter3Stage,
                    shaftLength3Stage),
                new Tuple<double, double, double>((shaftLength3Stage + shaftLength4Stage + shaftLength5Stage/2),
                    shaftDiameter2Stage, shaftLength2Stage),
                new Tuple<double, double, double>(
                    (shaftLength2Stage + shaftLength3Stage + shaftLength4Stage + shaftLength5Stage/2),
                    shaftDiameter1Stage, shaftLength1Stage)
            };

            foreach (var stage in stages)
            {
                _api.MakeNewWorkingPlane(1, stage.Item1);
                _api.DrawCircle(0.0, shaftLength5Stage/2, stage.Item2);
                _api.Extrude(stage.Item3);
            }

            
            #region chamfer

            _api.DrawChamfer(groove/1.5, NumberOfStage.Stage5);

            var chamflers = new List<Tuple<double>>
            {
                new Tuple<double>(shaftDiameter4Stage - shaftDiameter3Stage),
                new Tuple<double>(shaftDiameter3Stage - shaftDiameter2Stage),
                new Tuple<double>(shaftDiameter2Stage - shaftDiameter1Stage),
                new Tuple<double>(groove)
            };
            for (var i = 0; i < chamflers.Count; i++)
            {
                _api.DrawChamfer(chamflers[i].Item1/2, (NumberOfStage) i);
            }

            #endregion chamfer
            
           
            _api.DrawText(_valProperties.Caption, _valProperties.GetPointX(), 0.0,
                _valProperties.GetPointZ(), _valProperties.OrientationParameterType);

            #region PAZ

            var halfPointY1Stage = shaftDiameter1Stage/4;
            var halfWidthKeyway1Stage = widthKeyway1Stage/2;
            var halfLengthKeyway1Stage = lengthKeyway1Stage/2;
            var halfPointX1Stage = (shaftLength1Stage/2 + shaftLength2Stage + shaftLength3Stage +
                                    shaftLength4Stage + shaftLength5Stage/2);

            // Построение шпоночного паза первой ступени.
            _api.MakeNewWorkingPlane(2, (shaftDiameter1Stage/2 - heightKeyway1Stage));
            _api.CutExtrudeRectangle(-halfPointX1Stage + halfLengthKeyway1Stage,
                halfPointY1Stage + halfWidthKeyway1Stage,
                -halfPointX1Stage - halfLengthKeyway1Stage, halfPointY1Stage - halfWidthKeyway1Stage, heightKeyway1Stage);
            _api.CutExtrudeCircle(-halfPointX1Stage + halfLengthKeyway1Stage, halfPointY1Stage, widthKeyway1Stage, heightKeyway1Stage);
            _api.CutExtrudeCircle(-halfPointX1Stage - halfLengthKeyway1Stage, halfPointY1Stage, widthKeyway1Stage, heightKeyway1Stage);

            var halfPointY3Stage = shaftDiameter3Stage/4;
            var halfWidthKeyway3Stage = widthKeyway3Stage/2;
            var halfLengthKeyway3Stage = lengthKeyway3Stage/2;
            var halfPointX3Stage = (shaftLength3Stage/2 + shaftLength4Stage + shaftLength5Stage/2);

            // Построение шпоночного паза третьей ступени.
            _api.MakeNewWorkingPlane(2, (shaftDiameter3Stage/2 - heightKeyway3Stage));
            _api.CutExtrudeRectangle(-halfPointX3Stage + halfLengthKeyway3Stage,
                halfPointY3Stage + halfWidthKeyway3Stage,
                -halfPointX3Stage - halfLengthKeyway3Stage, halfPointY3Stage - halfWidthKeyway3Stage, heightKeyway3Stage);
            _api.CutExtrudeCircle(-halfPointX3Stage + halfLengthKeyway3Stage, halfPointY3Stage, widthKeyway3Stage, heightKeyway3Stage);
            _api.CutExtrudeCircle(-halfPointX3Stage - halfLengthKeyway3Stage, halfPointY3Stage, widthKeyway3Stage, heightKeyway3Stage);

            #endregion PAZ

        }

        #endregion

    }
}
