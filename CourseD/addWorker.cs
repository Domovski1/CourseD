using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseD
{
    public partial class addWorker : Form
    {
        string constring = @"Data Source=DESKTOP-QEO06O0;Initial Catalog=DomovskiBase;Integrated Security=True";

        public addWorker()
        {
            InitializeComponent();
            movePanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmd = $"INSERT INTO Workers ([name], [surname], patronymic, post, born, telephone, [address])VALUES('{txtName.Text}', '{txtSurname.Text}', '{txtPatronymic.Text}', '{txtPost.Text}', '{dateTimePicker1.Value.ToString()}', '{textBox1.Text}', '{txtAddress.Text}')";
            MessageBox.Show("Дата слишком велика!", "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //sqlComando(cmd);
        }

        
        void sqlComando(string cmd)
        {
            try
            {
                using (SqlConnection conet = new SqlConnection(constring))
                {
                    conet.Open();
                    SqlCommand comand = new SqlCommand(cmd, conet);
                    comand.ExecuteNonQuery();

                    MessageBox.Show("Данные Добавлены!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Исключение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         void movePanel()
         {
             int move = 0, moveX = 0, moveY = 0; ;
             PnlUp.MouseDown += (s, e) => { move = 1; moveX = e.X; moveY = e.Y; };
             PnlUp.MouseMove += (s, e) => { if (move == 1) SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY); };
             PnlUp.MouseUp += (s, e) => { move = 0; };
         }
        
    }
}
