using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Val
{
    public class Class1
    {
        public int A
        { get; set; }

        public int B
        { get; set; }

        /*
            //Пятая ступень вала
            _api.MakeNewWorkingPlane(1, -shaftLength5Stage / 2);
            _api.DrawCircle(0.0, shaftLength5Stage / 2, shaftDiameter5Stage);
            _api.Extrude(shaftLength5Stage);
            
            //отрисовка канавки
            _api.MakeNewWorkingPlane(2, 0);
            _api.DrawLine(0, 0, shaftLength5Stage / 2, shaftDiameter5Stage / 2);
            _api.DrawCircle(-shaftLength5Stage / 2, (shaftDiameter5Stage - 20 - (groove / 2)), groove);

           
            //_api.CutExtrudeCircle(2, (ShaftDiameter5Stage - 20 - (Groove/2)), Groove, 5.0);
             //_api.RevolveFull(0.0, 0.0, -1.0, 0.0);
            //_api.Extrude(ShaftLength5Stage);
            
            //4 ступень вала
            _api.MakeNewWorkingPlane(1, shaftLength5Stage /2);
            _api.DrawCircle(0.0, shaftLength5Stage / 2, shaftDiameter4Stage);
            _api.Extrude(shaftLength4Stage);
            
            //3 ступень вала
            _api.MakeNewWorkingPlane(1, (shaftLength4Stage + shaftLength5Stage / 2));
            _api.DrawCircle(0.0, shaftLength5Stage / 2, shaftDiameter3Stage);
            _api.Extrude(shaftLength3Stage);

             //2 ступень вала
            _api.MakeNewWorkingPlane(1, (shaftLength3Stage + shaftLength4Stage + shaftLength5Stage / 2));
            _api.DrawCircle(0.0, shaftLength5Stage / 2, shaftDiameter2Stage);
            _api.Extrude(shaftLength2Stage);

            //1 ступень вала
            _api.MakeNewWorkingPlane(1, (shaftLength2Stage + shaftLength3Stage + shaftLength4Stage + shaftLength5Stage / 2));
            _api.DrawCircle(0.0, shaftLength5Stage / 2, shaftDiameter1Stage);
            _api.Extrude(shaftLength1Stage);

            var halfPointY1Stage = shaftDiameter1Stage/4;
            var halfWidthKeyway1Stage = widthKeyway1Stage/2;
            var halfLengthKeyway1Stage = lengthKeyway1Stage/2;
            var halfPointX1Stage = (shaftLength1Stage/2 + shaftLength2Stage + shaftLength3Stage + 
                shaftLength4Stage + shaftLength5Stage/2);
            
             */
            //sponochniy paz 1 stupeny
            _api.MakeNewWorkingPlane(2, (shaftDiameter1Stage / 2 - heightKeyway1Stage));
            _api.CutExtrudeRectangle(-halfPointX1Stage + halfLengthKeyway1Stage, halfPointY1Stage + halfWidthKeyway1Stage,
                -halfPointX1Stage - halfLengthKeyway1Stage, halfPointY1Stage - halfWidthKeyway1Stage, heightKeyway1Stage);
            _api.CutExtrudeCircle(-halfPointX1Stage + halfLengthKeyway1Stage, halfPointY1Stage, 20, heightKeyway1Stage);
            _api.CutExtrudeCircle(-halfPointX1Stage - halfLengthKeyway1Stage, halfPointY1Stage, 20, heightKeyway1Stage);

            var halfPointY3Stage = shaftDiameter3Stage / 4;
            var halfWidthKeyway3Stage = widthKeyway3Stage / 2;
            var halfLengthKeyway3Stage = lengthKeyway3Stage / 2;
            var halfPointX3Stage = (shaftLength3Stage / 2 + shaftLength4Stage + shaftLength5Stage / 2);

            //sponochniy paz 3 stupeny
            _api.MakeNewWorkingPlane(2, (shaftDiameter3Stage / 2 - heightKeyway3Stage));
           //_api.CutExtrudeRectangle(-halfPointX3Stage + halfLengthKeyway3Stage, halfPointY3Stage + halfWidthKeyway3Stage,  -halfPointX3Stage - halfLengthKeyway3Stage, halfPointY3Stage - halfWidthKeyway3Stage, HeightKeyway3Stage);
            
            _api.CutExtrudeRectangle(-halfPointX3Stage + halfLengthKeyway3Stage, halfPointY3Stage + halfWidthKeyway3Stage,
                -halfPointX3Stage - halfLengthKeyway3Stage, halfPointY3Stage - halfWidthKeyway3Stage, heightKeyway3Stage);
            _api.CutExtrudeCircle(-halfPointX3Stage + halfLengthKeyway3Stage, halfPointY3Stage, 20, heightKeyway3Stage);
            _api.CutExtrudeCircle(-halfPointX3Stage - halfLengthKeyway3Stage, halfPointY3Stage, 20, heightKeyway3Stage);
            
    }
}
