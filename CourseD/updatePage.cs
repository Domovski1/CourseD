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
    public partial class updatePage : Form
    {
        string constring = @"Data Source=DESKTOP-QEO06O0;Initial Catalog=DomovskiBase;Integrated Security=True";

        public updatePage()
        {
            InitializeComponent();
            movePanel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string upd = "";// = $"UPDATE Workers SET [name] = '{txtName.Text}', surname = '{txtSurname.Text}', patronymic = '{txtPatronymic.Text}', post = '{txtPost.Text}', born = '{dateTimePicker1.Value.ToString()}', telephone = '{textBox2.Text}', [address] = '{txtAddress.Text}'  WHERE ID = '{textBox1.Text}'";
            SqlComando(upd);
        }


        void SqlComando (string cmd)
        {
            try
            {
                using (SqlConnection conet = new SqlConnection(constring))
                {
                    conet.Open();
                    SqlCommand comand = new SqlCommand(cmd, conet);
                    comand.ExecuteNonQuery();

                    MessageBox.Show("Данные Изменены!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
