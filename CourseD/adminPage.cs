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
    public partial class adminPage : Form
    {
        string constring = @"Data Source=DESKTOP-QEO06O0;Initial Catalog=DomovskiBase;Integrated Security=True";
        public adminPage()
        {
            InitializeComponent();
            movePanel();
            dataFull();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // Поиск 
        private void button4_Click(object sender, EventArgs e)
        {
            string sel = $"SELECT * FROM Workers WHERE [name] = '{textBox1.Text}'";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле является пустым, пожалуйста, введите данные для поиска!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataFull();
            } else if (textBox1.Text != "")
            sqlComando(sel);
            MessageBox.Show("Данные отсутствуют! Проверьте на корректность веденные данные!", "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }

        // Страница для добавления данных
        private void button1_Click(object sender, EventArgs e)
        {
            addWorker add = new addWorker();
            add.Show();
        }

        // Страница для изменения данных
        private void button2_Click(object sender, EventArgs e)
        {
            updatePage uPage = new updatePage();
            uPage.Show();
        }

        // Кнопка удаления данных
        private void button3_Click(object sender, EventArgs e)
        {
            string del = $"DELETE FROM Workers WHERE [ID] = '{textBox2.Text}'";
            deleteDates(del);
        }



        #region
        // Для заполнения таблицы данными.
        void dataFull()
        {
            string sel = $"SELECT * FROM Clients";

            using (SqlConnection conet = new SqlConnection(constring))
            {
                conet.Open();
                SqlCommand comand = new SqlCommand(sel, conet);
                SqlDataAdapter adapter = new SqlDataAdapter(comand);
                DataTable table = new DataTable();

                adapter.Fill(table);
                DGV.DataSource = table;
                    
            }
        }

        // Движение панели
        void movePanel()
        {
            int move = 0, moveX = 0, moveY = 0; ;
            PnlUp.MouseDown += (s, e) => { move = 1; moveX = e.X; moveY = e.Y; };
            PnlUp.MouseMove += (s, e) => { if (move == 1) SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY); };
            PnlUp.MouseUp += (s, e) => { move = 0; };
        }           

        // Команда для вывода данных поиска
        void sqlComando (string sel)
        {
            try
            {
                using (SqlConnection conet = new SqlConnection(constring))
                {
                    conet.Open();
                    SqlCommand comand = new SqlCommand(sel, conet);
                    SqlDataAdapter adapter = new SqlDataAdapter(comand);
                    DataTable table = new DataTable();

                    adapter.Fill(table);
                    DGV.DataSource = table;


                    MessageBox.Show("Данные выведены!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Исключение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удаление данных
        void deleteDates (string cmd)
        {
            try
            {
                using (SqlConnection conet = new SqlConnection(constring))
                {
                    conet.Open();
                    SqlCommand comand = new SqlCommand(cmd, conet);
                    comand.ExecuteNonQuery();
                    MessageBox.Show("Данные Удалены!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Исключение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                dataFull();
            }
        }

        #endregion

    }
}
