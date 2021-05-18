using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseD
{
    public partial class Form1 : Form
    {
        string constring = @"Data Source=DESKTOP-QEO06O0;Initial Catalog=DomovskiBase;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            movePanel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введены несуществующие данные!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            // autorization();
        }

        void movePanel()
        {
            int move = 0, moveX = 0, moveY = 0; ;
            PnlUp.MouseDown += (s, e) => { move = 1; moveX = e.X; moveY = e.Y; };
            PnlUp.MouseMove += (s, e) => { if (move == 1) SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY); };
            PnlUp.MouseUp += (s, e) => { move = 0; };
        }


        void autorization()
        {
            try
            {
                using (SqlConnection conect = new SqlConnection(constring))
                {
                    string cmd = $"SELECT * FROM Autorization WHERE [login] = '{textBox1.Text}' and password = '{textBox2.Text}'";
                    conect.Open();
                    SqlCommand comand = new SqlCommand(cmd, conect);
                    SqlDataReader reader = comand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (reader.GetValue(1).ToString() == $"{textBox1.Text}" && reader.GetValue(2).ToString() == $"{textBox2.Text}")
                        {
                            if (reader.GetValue(3).ToString() == "admin")
                            {
                                adminPage admPage = new adminPage();
                                Hide();
                                admPage.Show();

                            }
                            else if (reader.GetValue(3).ToString() == "worker")
                            {
                                workerPage workPage = new workerPage();
                                workPage.Show();
                                Hide();
                            }
                            else
                                MessageBox.Show("This invalid dates");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
