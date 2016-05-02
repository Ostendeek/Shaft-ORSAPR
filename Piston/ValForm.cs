using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.IO;


namespace Val
{
    public partial class ValForm : Form
    {
        /// <summary>
        /// Параметры модели.
        /// </summary>
        private readonly ValProperties _valProperties = new ValProperties();

        /// <summary>
        /// Модель вала.
        /// </summary>
        private ValModel _valModel;

        /// <summary>
        /// Интерфейс САПР API.
        /// </summary>
        private InventorApi _inventorApi;

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

        public ValForm()
        {
            InitializeComponent();
            InitParameters();
        }

        
        /// <summary>
        /// Инициализация параметров.
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
            lengthKWUpDown1.Parameter = _valProperties.GetParameter(ParameterType.LengthKeyway1Stage);
            lengthKWUpDown3.Parameter = _valProperties.GetParameter(ParameterType.LengthKeyway3Stage);
            widthKWUpDown1.Parameter = _valProperties.GetParameter(ParameterType.WidthKeyway1Stage);
            widthKWUpDown3.Parameter = _valProperties.GetParameter(ParameterType.WidthKeyway3Stage);
            heightKWrUpDown1.Parameter = _valProperties.GetParameter(ParameterType.HeightKeyway1Stage);
            heightKWUpDown3.Parameter = _valProperties.GetParameter(ParameterType.HeightKeyway3Stage);
          
        }

        /// <summary>
        /// Построение модели.
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void BuildVal_Click(object sender, EventArgs e)
        {
            // Stopwatch stopwatch = new Stopwatch();
            //var listTimes = new List<string>();

            //for (int i = 0; i < 20; i++)
            {
                // stopwatch.Start();
                _inventorApi = new InventorApi();
                _valProperties.SetCaption(GetOrientation(), (NumberOfStage)selectComboBox.SelectedIndex,
                    (OrientationParameterType)orientComboBox.SelectedIndex, captionTextBox.Text);
                _valModel = new ValModel(_valProperties, _inventorApi);

                _valModel.Build();
                // stopwatch.Stop();
                // listTimes.Add(stopwatch.Elapsed.ToString());
                // stopwatch.Reset();
            }
            /*
            StreamWriter file = new StreamWriter(@"C:\Users\ostende\Documents\WriteTimes50.txt");
            {
                foreach (string line in listTimes)
                    file.WriteLine(line);
            }
            file.Close();
            */
        }

        private ParameterType GetOrientation()
        {
            var orientation = _orientationRu.FirstOrDefault(x => x.Value == orientComboBox.Text).Key;
            var numberOfStage = _stagesRu.FirstOrDefault(x => x.Value == selectComboBox.Text).Key;

            return orientation == OrientationParameterType.Horizontal
                ? _horizontalOrientation[numberOfStage]
                : _verticalOrientation[numberOfStage];
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        
    }
}
