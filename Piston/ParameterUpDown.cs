using System;
using System.Windows.Forms;

namespace Val
{
    
    public partial class ParameterUpDown : UserControl
    {
        private Parameter _parameter;

        private bool _inited;

        private bool _parameterOnParameterChangedStopped;

        public ParameterUpDown()
        {
            InitializeComponent();
            numericUpDown1.ValueChanged += NumericUpDown1OnValueChanged;
        }

        /// <summary>
        /// Обработчик события изменения значения контрола.
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="eventArgs">Параметры</param>
        private void NumericUpDown1OnValueChanged(object sender, EventArgs eventArgs)
        {
            if (!_inited)
                return;

            _parameterOnParameterChangedStopped = true;

            _parameter.Min = Convert.ToDouble(numericUpDown1.Minimum);
            _parameter.Max = Convert.ToDouble(numericUpDown1.Maximum);
            _parameter.Value = Convert.ToDouble(numericUpDown1.Value);

            _parameterOnParameterChangedStopped = false;
        }
        /// <summary>
        /// Свойства метода Parameter.
        /// </summary>
        public Parameter Parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter == value)
                    return;
                if (_parameter != null)
                {
                    _parameter.ParameterChanged -= ParameterOnParameterChanged;
                }
                if (value != null)
                {
                    value.ParameterChanged += ParameterOnParameterChanged;
                    numericUpDown1.Minimum = Convert.ToDecimal(value.Min);
                    numericUpDown1.Maximum = Convert.ToDecimal(value.Max);
                    numericUpDown1.Value = Convert.ToDecimal(value.Value);
                    _inited = true;
                }
                else
                {
                    _inited = false;
                }
                _parameter = value;
            }
        }
       /// <summary>
       /// Обаботчик события изменения параметра.
       /// </summary>
        /// <param name="sender">Отправитель события</param>
       /// <param name="eventArgs">Параметры</param>
        private void ParameterOnParameterChanged(object sender, EventArgs eventArgs)
        {
            if (_parameterOnParameterChangedStopped || !_inited)
                return;

            var parameter = (Parameter) sender;
            numericUpDown1.Minimum = Convert.ToDecimal(parameter.Min);
            numericUpDown1.Maximum = Convert.ToDecimal(parameter.Max);
            numericUpDown1.Value = Convert.ToDecimal(parameter.Value);
        }
    }
}
