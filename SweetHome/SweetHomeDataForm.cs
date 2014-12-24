using System;
using System.Windows.Forms;
using DataControllManager;
using Manager;

namespace SweetHome
{
    /// <summary>
    /// Диалоговый класс SweetHomeDataForm
    /// </summary>
    public partial class SweetHomeDataForm : Form
    {
        /// <summary>
        /// Ссылка на класс GrateDescription
        /// </summary>
        private GrateDiscription _grateDiscription = new GrateDiscription();

        /// <summary>
        /// Ссылка на класс Vizualizator
        /// </summary>
        private Vizualizator _vizualizator = new Vizualizator();

        /// <summary>
        /// Поле, описывающее возможность построения трубы 
        /// </summary>
        private bool _isExist;

        /// <summary>
        /// Конструктор диалогового класса SweetHomeDataForm
        /// </summary>
        public SweetHomeDataForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Зарузка формы
        /// </summary>
        private void SweetHomeDataForm_Load(object sender, EventArgs e)
        {
            YesRadioButton.Checked = true;
        }

        //Stopwatch test = new Stopwatch();

        /// <summary>
        /// Обработчик нажатия кнопки "Построить"
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            //test.Start();
            //for (int i = 0; i < 10; i++)
            //{
            try
            {
                _vizualizator.InitVizualizator(_grateDiscription, _isExist);
            }
                catch (ArgumentNullException)
            {

                MessageBox.Show(@"Введены не все параметры. Введите пожалуйста все параметры.");
            }
                //MessageBox.Show(test.ElapsedMilliseconds.ToString());
                //test.Reset();
            //}
            //test.Stop();
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (высота фундамента) в comboBox1
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void HeightFoundation_leave(object sender, EventArgs e)
        {
            try
            {
                _grateDiscription.FoundationHeight = Convert.ToDouble(HeightFoundation.Text);
                _grateDiscription.AshpitHeight = 7; //невводимый параметр 
            }
            
            catch (FormatException)
            {
                MessageBox.Show(@"Введите корректные данные в поле 'Высота фундамента'");
                HeightFoundation.Undo();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                HeightFoundation.Undo();
            }
            
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (ширина фундамента) в comboBox1
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void WidthFoundation_leave(object sender, EventArgs e)
        {
            if (HeightFoundation != null)
            {
                try
                {
                        _grateDiscription.FoundationWidth = Convert.ToDouble(WidthFoundation.Text);
                        _grateDiscription.AshpitWidth = 15;
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Ширина фундамента'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    WidthFoundation.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    WidthFoundation.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите высоту фундамента");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (длина фундамента) в comboBox7
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void LengthFoundation_leave(object sender, EventArgs e)
        {
            if (WidthFoundation != null)
            {
                try
                {
                        _grateDiscription.FoundationLength = Convert.ToDouble(LengthFoundation.Text);
                        _grateDiscription.AshpitLength = _grateDiscription.FoundationLength - 5; //невводимый параметр
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Длина фудамента'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    LengthFoundation.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    LengthFoundation.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите ширину фундамента");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (высота надфундаментной плиты) в comboBox3
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void HeightFoundationPlate_leave(object sender, EventArgs e)
        {
            if (LengthFoundation != null)
            {
                try
                {
                    _grateDiscription.FoundationPlateHeight = Convert.ToDouble(HeightFoundationPlate.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Высота надфундаментной плиты'"); 
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    HeightFoundationPlate.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    HeightFoundationPlate.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите параметры фундамента");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (ширина надфундаментной плиты) в comboBox2
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void WidthFoundationPlate_leave(object sender, EventArgs e)
        {
            if (HeightFoundationPlate != null)
            {
                try
                {
                    {
                        _grateDiscription.FoundationPlateWidth = Convert.ToDouble(WidthFoundationPlate.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Ширина надфундаментной плиты'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    WidthFoundationPlate.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    WidthFoundationPlate.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите высоту надфундаментной плиты");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (длина надфундаментной плиты) в comboBox9
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void LengthFoundationPlate_leave(object sender, EventArgs e)
        {
            if (WidthFoundationPlate != null)
            {
                try
                {
                    {
                        _grateDiscription.FoundationPlateLength = Convert.ToDouble(LengthFoundationPlate.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Длина надфундаментной плиты'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    LengthFoundationPlate.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    LengthFoundationPlate.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите ширину надфундаментной плиты");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (высота печного блока) в comboBox4
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void HeightFurnaceBlock_leave(object sender, EventArgs e)
        {
            if (LengthFoundationPlate != null)
            {
                try
                {
                    {
                        _grateDiscription.FurnaceBlockHeight = Convert.ToDouble(HeightFurnaceBlock.Text);
                        _grateDiscription.BurnerHeight = _grateDiscription.FurnaceBlockHeight - 8; //невводимый
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Высота печного блока'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    HeightFurnaceBlock.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите параметры фундамента");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (ширина печного блока) в comboBox10
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void WidthFurnaceBlock_leave(object sender, EventArgs e)
        {
            if (HeightFurnaceBlock != null)
            {
                try
                {
                    {
                        _grateDiscription.FurnaceBlockWidth = Convert.ToDouble(WidthFurnaceBlock.Text);
                        _grateDiscription.BurnerWidth = _grateDiscription.FurnaceBlockWidth - 16;//невводимый (ширина топки)
                        _grateDiscription.ChimneyHeight = 18; //невводимый (высота дымохода)
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Ширина печного блока'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    WidthFurnaceBlock.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    WidthFurnaceBlock.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите высоту печного блока");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (длина печного блока) в comboBox5
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void LengthFurnaceBlock_leave(object sender, EventArgs e)
        {
            if (WidthFurnaceBlock != null)
            {
                try
                {
                    {
                        _grateDiscription.FurnaceBlockLength = Convert.ToDouble(LengthFurnaceBlock.Text);
                        _grateDiscription.BurnerLength = _grateDiscription.FurnaceBlockLength - 8; //невводимый
                        _grateDiscription.ChimneyWidth = 10; //невводимый
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Длина печного блока'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    LengthFurnaceBlock.Undo();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    LengthFurnaceBlock.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите ширину печного блока");
            }
        }

        /// <summary>
        /// Обработчик RadioButton1 для значения Yes
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void YesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PipeGroupBox.Visible = true;
            _isExist = true;
        }

        /// <summary>
        /// Обработчик RadioButton2 для значения No
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void NoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PipeGroupBox.Visible = false;
            HeightPipe.Clear();
            HeightMantel.Clear();
            _isExist = false;
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (высота трубы) в comboBox4
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void HeightPipe_leave(object sender, EventArgs e)
        {
            if (LengthFurnaceBlock != null)
            {
                try
                {
                    _grateDiscription.PipeHeight = Convert.ToDouble(HeightPipe.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Высота трубы'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    HeightPipe.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала введите параметры печного блока");
            }
        }

        /// <summary>
        /// Обработчик при выборе(введении) параметра элемента (высота огранки) в comboBox11
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (попадание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void HeightMantel_leave(object sender, EventArgs e)
        {
            if (HeightPipe != null)
            {
                try
                {
                    _grateDiscription.MantelHeight = Convert.ToDouble(HeightMantel.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show(@"Введите корректные данные в поле 'Высота огранки'");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
                    HeightMantel.Undo();
                }
            }
            else
            {
                MessageBox.Show(@"Сначала высоту трубы");
            }
        }
    }
}
