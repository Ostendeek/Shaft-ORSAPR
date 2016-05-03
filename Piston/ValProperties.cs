using System;
using System.Collections.Generic;
using Inventor;

namespace Val
{
    /// <summary>
    /// Параметры модели.
    /// </summary>
    public class ValProperties
    {
        /// <summary>
        /// Словарь параметров.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters;

        /// <summary>
        /// Надпись.
        /// </summary>
        private string _caption;

        private readonly Dictionary<NumberOfStage, string> _stagesRu = new Dictionary<NumberOfStage, string>
            {
                {NumberOfStage.Stage1, "Первая ступень"},
                {NumberOfStage.Stage2, "Вторая ступень"},
                {NumberOfStage.Stage3,"Третья ступень"},
                {NumberOfStage.Stage4, "Четвертая ступень"},
                {NumberOfStage.Stage5, "Пятая ступень"},
            };

        private readonly Dictionary<OrientationParameterType, string> _orientationRu = new Dictionary<OrientationParameterType, string>
            {
                {OrientationParameterType.Horizontal, "Горизонтальная"},
                {OrientationParameterType.Vertical, "Вертикальная"},
         
            };

        private readonly Dictionary<NumberOfStage, ParameterType> _horizontalOrientation = new Dictionary<NumberOfStage, ParameterType>
            {
                {NumberOfStage.Stage1, ParameterType.ShaftDiameter1Stage},
                {NumberOfStage.Stage2, ParameterType.ShaftDiameter2Stage},
                {NumberOfStage.Stage3,ParameterType.ShaftDiameter3Stage},
                {NumberOfStage.Stage4, ParameterType.ShaftDiameter3Stage},
                {NumberOfStage.Stage5, ParameterType.ShaftDiameter5Stage},
            };

        private readonly Dictionary<NumberOfStage, ParameterType> _verticalOrientation = new Dictionary<NumberOfStage, ParameterType>
            {
                {NumberOfStage.Stage1, ParameterType.ShaftLength1Stage},
                {NumberOfStage.Stage2, ParameterType.ShaftLength2Stage},
                {NumberOfStage.Stage3,ParameterType.ShaftLength3Stage},
                {NumberOfStage.Stage4, ParameterType.ShaftLength4Stage},
                {NumberOfStage.Stage5, ParameterType.ShaftLength5Stage},
            };


        /// <summary>
        /// Сеттер и геттер надписи.
        /// </summary>
        public string Caption
        {
            get { return _caption; }
        }

        private NumberOfStage _numberOfStage;

        /// <summary>
        /// Сеттер надписи.
        /// </summary>
        /// <param name="parameterType">Параметр вала</param>
        /// <param name="numberOfStage">Номер ступени</param>
        /// <param name="orientationParameterType">Ориентация</param>
        /// <param name="text">Надпись</param>
        public void SetCaption(ParameterType parameterType, NumberOfStage numberOfStage,
            OrientationParameterType orientationParameterType, string text)
        {
            var parameter = _parameters[parameterType];
            _numberOfStage = numberOfStage;
            _caption = text;
            try
            {
                int lettersCount = Convert.ToInt32(parameter.Value/25.0);
                if (_caption.Length < lettersCount + 1)
                {
                }
            }
            catch
            {
                throw;
            }

        }

        #region Methods

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ValProperties()
        {
            _parameters = new Dictionary<ParameterType, Parameter>
            {
                {ParameterType.ShaftDiameter1Stage, new Parameter(43.55, 67.0, 90.45)},
                {ParameterType.ShaftDiameter2Stage, new Parameter(46.8, 72.0, 97.2)},
                {ParameterType.ShaftDiameter3Stage, new Parameter(52.0, 80.0, 108.0)},
                {ParameterType.ShaftDiameter4Stage, new Parameter(55.25, 85.0, 114.75)},
                {ParameterType.ShaftDiameter5Stage, new Parameter(46.8, 72.0, 97.2)},
                {ParameterType.ShaftLength1Stage, new Parameter(71.5, 110.0, 148.0)},
                {ParameterType.ShaftLength2Stage, new Parameter(55.25, 85.0, 114.75)},
                {ParameterType.ShaftLength3Stage, new Parameter(52.0, 80.0, 108.0)},
                {ParameterType.ShaftLength4Stage, new Parameter(34.45, 53.0, 71.55)},
                {ParameterType.ShaftLength5Stage, new Parameter(20.8, 32.0, 43.2)},
                {ParameterType.Groove, new Parameter(1.0, 5.0, 20.0)},
                {ParameterType.WidthKeyway1Stage, new Parameter(12.0, 20.0, 24.0)},
                {ParameterType.HeightKeyway1Stage, new Parameter(8.0, 12.0, 14.0)},
                {ParameterType.LengthKeyway1Stage, new Parameter(16.0, 36.0, 39.0)},
                {ParameterType.WidthKeyway3Stage, new Parameter(16.0, 22.0, 26.0)},
                {ParameterType.HeightKeyway3Stage, new Parameter(10.0, 14.0, 16.0)},
                {ParameterType.LengthKeyway3Stage, new Parameter(29.0, 39.0, 44.0)}                 
            };

            foreach (var parameter in _parameters.Values)
            {
                parameter.ParameterChanged += ParameterOnParameterChanged;
            }
        }

        /// <summary>
        /// Слот, вызываемый при изменении какого-либо параметра модели.
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Аргументы</param>
        private void ParameterOnParameterChanged(object sender, EventArgs e)
        {
            Validate();
        }
        
        /// <summary>
        /// Получить параметр.
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <returns>Полученный параметр</returns>
        public Parameter GetParameter(ParameterType parameterType)
        {
            return _parameters[parameterType];
        }
        
        /// <summary>
        /// Получить координату Z.
        /// </summary>
        /// <returns>Полученное значение</returns>
        public double GetPointZ()
        {
            switch (_numberOfStage)
            {
                case NumberOfStage.Stage1:
                    return GetParameter(ParameterType.ShaftDiameter1Stage).Value/2;          
                case NumberOfStage.Stage2:
                    return GetParameter(ParameterType.ShaftDiameter2Stage).Value/2; 
                case NumberOfStage.Stage3:
                    return GetParameter(ParameterType.ShaftDiameter3Stage).Value / 2;
                case NumberOfStage.Stage4:
                    return GetParameter(ParameterType.ShaftDiameter4Stage).Value/2;
                case NumberOfStage.Stage5:
                    return GetParameter(ParameterType.ShaftDiameter5Stage).Value / 2;
            }
            throw new ApplicationException("There is no such number of stage!");
        }

        /// <summary>
        /// Получить координату Х.
        /// </summary>
        /// <returns>Полученное значение</returns>
        public double GetPointX()
        {
            switch (_numberOfStage)
            {
                case NumberOfStage.Stage1:
                    return (-GetParameter(ParameterType.ShaftLength5Stage).Value/ 2
                            - GetParameter(ParameterType.Groove).Value)*1.5 ;
                case NumberOfStage.Stage2:
                    return (-GetParameter(ParameterType.ShaftLength5Stage).Value
                            - GetParameter(ParameterType.Groove).Value) / 2;
                case NumberOfStage.Stage3:
                    return (-GetParameter(ParameterType.ShaftLength4Stage).Value 
                        - GetParameter(ParameterType.ShaftLength5Stage).Value
                        - GetParameter(ParameterType.ShaftLength3Stage).Value
                        -GetParameter(ParameterType.Groove).Value) / 20;
                case NumberOfStage.Stage4:
                    return (-GetParameter(ParameterType.ShaftLength4Stage).Value 
                        - GetParameter(ParameterType.ShaftLength5Stage).Value) / 20;
                case NumberOfStage.Stage5:
                    return 0.0;
                 
            }
            throw new ApplicationException("There is no such number of stage!");
        }


        /// <summary>
        /// Проверка значение и установка ограничений.
        /// </summary>
       private void Validate()
        {
            if (_parameters[ParameterType.ShaftLength1Stage].Value >=
                _parameters[ParameterType.LengthKeyway1Stage].Value)
            {
                _parameters[ParameterType.ShaftLength1Stage].Validate();
            }
            else
            {
                throw new ApplicationException("Enter the correct value of the keyway length!");
            }

            if (_parameters[ParameterType.ShaftDiameter1Stage].Value >=
                _parameters[ParameterType.HeightKeyway1Stage].Value)
            {
                throw new ApplicationException("Enter the correct value of the keyway height!");
            }
            else
            {
                _parameters[ParameterType.ShaftDiameter1Stage].Validate();
            }

            if (_parameters[ParameterType.ShaftLength3Stage].Value >=
                 _parameters[ParameterType.LengthKeyway3Stage].Value)
            {
                throw new ApplicationException("Enter the correct value of the keyway length!");
            }
            else
            {
                _parameters[ParameterType.ShaftLength3Stage].Validate();
            }

            if (_parameters[ParameterType.ShaftDiameter3Stage].Value >=
                _parameters[ParameterType.HeightKeyway3Stage].Value)
            {
                throw new ApplicationException("Enter the correct value of the keyway height!");
            }
            else
            {
                _parameters[ParameterType.ShaftDiameter3Stage].Validate();
            }
        }
        #endregion
    }
}
 