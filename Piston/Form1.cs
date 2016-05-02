using System;
using System.Windows.Forms;

namespace Val
{
    public partial class valForm1 : Form
    {
        /// <summary>
        /// Параметры модели
        /// </summary>
        private readonly ValProperties _valProperties = new ValProperties();

        /// <summary>
        /// Модель поршня
        /// </summary>
        private ValModel _valModel;

        /// <summary>
        /// Интерфейс САПР API
        /// </summary>
        private InventorApi _inventorApi;

        public valForm1()
        {
            InitializeComponent();
            InitParameters();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitParameters()
        {
            diameterShaftUpDown1.Parameter = _valProperties.GetParameter(ParameterType.ShaftDiameter1Stage);
            diameterShaftUpDown2.Parameter = _valProperties.GetParameter(ParameterType.ShaftDiameter2Stage);
            diameterShaftUpDown3.Parameter = _valProperties.GetParameter(ParameterType.ShaftDiameter3Stage);
            diameterShaftUpDown4.Parameter = _valProperties.GetParameter(ParameterType.ShaftDiameter4Stage);
            diameterShaftUpDown5.Parameter = _valProperties.GetParameter(ParameterType.ShaftDiameter5Stage);
            lengthShaftUpDown1.Parameter = _valProperties.GetParameter(ParameterType.ShaftLength1Stage);
            lengthShaftUpDown2.Parameter = _valProperties.GetParameter(ParameterType.ShaftLength2Stage);
            lengthShaftUpDown3.Parameter = _valProperties.GetParameter(ParameterType.ShaftLength3Stage);
            lengthShaftUpDown4.Parameter = _valProperties.GetParameter(ParameterType.ShaftLength4Stage);
            lengthShaftUpDown5.Parameter = _valProperties.GetParameter(ParameterType.ShaftLength5Stage);
            /*ring1HeightUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.Ring1Height);
            ring2WidthUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.Ring2Width);
            ring2HeightUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.Ring2Height);
            partitionHeightUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.PartitionHeight);
            rodLengthUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodLength);
            rodDiameterUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodDiameter);
            rodHeadWidthUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodHeadWidth);
            rodHead1DiameterUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodHead1Diameter);
            rodHead1WidthUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodHead1Width);
            rodHead2DiameterUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodHead2Diameter);
            rodHead2WidthUpDown.Parameter = _pistonProperties.GetParameter(ParameterType.RodHead2Width);*/

        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void buildPiston_Click(object sender, EventArgs e)
        {
            _inventorApi = new InventorApi();
            _valModel = new ValModel(_valProperties, _inventorApi);
            _valModel.Build();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
