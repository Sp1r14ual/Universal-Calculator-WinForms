namespace Universal_Calculator_WinForms
{
    public partial class Form1 : Form
    {
        /// Объъект класса Контроллер
        TCtrl ctrl = new TCtrl();

        /// Режим для работы с числами
        private string mode = "pNum";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Устанавливаем начальное значение в поле ввода
            textBox1.Text = ctrl.pNumber.StrNumber;
            // Устанавливаем начальное положение для трекбара
            trackBar1.Value = ctrl.pNumber.IntP;
            // Устанавливаем начальное значение для поля основания системы счисления
            textBox2.Text = ctrl.pNumber.IntP.ToString();
            // Обновляем состояние кнопок
            UpdateButtons();
        }

        // Обработка нажатия кнопок
        private void button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            int operation = Convert.ToInt16(button.Tag.ToString());
            DoCommand(operation);
        }

        /// Выполнить определенную команду 
        private void DoCommand(int command)
        {
            try
            {
                ctrl.DoCommandCalculator(command);
                string number = ctrl.pNumber.StrNumber;

                if (mode == "int")
                {
                    int indexDelim = number.IndexOf(',');

                    if (indexDelim != -1)
                    {
                        number = number.Remove(number.IndexOf(','));
                    }
                }

                textBox1.Text = number;

                // Обработка команды для кнопки C
                if (command == 20 || command == 31)
                {
                    trackBar1.Value = ctrl.pNumber.IntP;
                    textBox2.Text = ctrl.pNumber.IntP.ToString();
                    UpdateButtons();
                }
                // Обработка операций с памятью
                if (command >= 21 && command <= 24)
                {
                    UpdateButtons();
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Произошло переполнение даннных", "Ошибка");
                DoCommand(19);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                DoCommand(19);
            }
        }

        /// Обновление состояния кнопок
        private void UpdateButtons()
        {
            foreach (Control item in tabPage1.Controls)
            {
                if (item is System.Windows.Forms.Button)
                {
                    int tag = Convert.ToInt16(item.Tag.ToString());

                    if (tag < trackBar1.Value)
                    {
                        item.Enabled = true;
                        item.BackColor = Color.Blue;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    if (tag >= trackBar1.Value && tag <= 15)
                    {
                        item.Enabled = false;
                        item.BackColor = Color.LightGray;
                    }
                    if ((tag == 21 || tag == 22) && ctrl.GetMemoryState() == "On")
                    {
                        item.Enabled = true;
                        item.BackColor = Color.LightSeaGreen;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    if ((tag == 21 || tag == 22) && ctrl.GetMemoryState() == "Off")
                    {
                        item.Enabled = false;
                        item.BackColor = Color.LightGray;
                    }
                }
            }
        }

        // Обработка изменения положения ползунка трекбара
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ctrl.pNumber.IntP = trackBar1.Value;
            textBox2.Text = ctrl.pNumber.IntP.ToString();
            UpdateButtons();
            DoCommand(19);
        }

        // Обработка нажатия клавиш
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int operation = -1;
            if (e.KeyChar >= 'A' && e.KeyChar <= 'F')
            {
                operation = (int)e.KeyChar - 'A' + 10;
            }
            else if (e.KeyChar >= 'a' && e.KeyChar <= 'f')
            {
                operation = (int)e.KeyChar - 'a' + 10;
            }
            else if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                operation = (int)e.KeyChar - '0';
            }
            else if ((e.KeyChar == '.' || e.KeyChar == ','))
            {
                operation = 17;
            }
            else if ((int)e.KeyChar == 8)
            {
                operation = 18;
            }
            else if (e.KeyChar == '=')
            {
                operation = 31;
            }
            else if (e.KeyChar == '/')
            {
                operation = 28;
            }
            else if (e.KeyChar == '*')
            {
                operation = 27;
            }
            else if (e.KeyChar == '+')
            {
                operation = 25;
            }
            else if (e.KeyChar == '-')
            {
                operation = 26;
            }
            if (((operation < trackBar1.Value) || (operation >= 16)) && (operation != -1))
            {
                DoCommand(operation);
            }

            textBox1.SelectionStart = ctrl.pNumber.StrNumber.Length;
            e.Handled = true;
        }

        // Обработка нажатия управляющих клавиш
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DoCommand(20);
            }
            if (e.KeyCode == Keys.Enter)
            {
                DoCommand(31);
            }
            textBox1.SelectionStart = ctrl.pNumber.StrNumber.Length;
        }

        // Обработка изменения режима на числа в СС с основанием P
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.ChangeTCtrlMode(1);
            trackBar1.Enabled = true;
            button33.Enabled = false;
            mode = "pNum";
            UpdateButtons();
            DoCommand(20);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.ChangeTCtrlMode(2);
            trackBar1.Enabled = false;
            button33.Enabled = false;
            UpdateButtons();
            DoCommand(20);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.ChangeTCtrlMode(3);
            trackBar1.Enabled = false;
            button33.Enabled = true;
            UpdateButtons();
            DoCommand(20);
        }
    }
}
