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
    public partial class workerPage : Form
    {
        string constring = @"Data Source=DESKTOP-QEO06O0;Initial Catalog=DomovskiBase;Integrated Security=True";

        public workerPage()
        {
            InitializeComponent();
            dataFull();
            movePanel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        
        
        #region voids
        void movePanel()
        {
            int move = 0, moveX = 0, moveY = 0; ;
            PnlUp.MouseDown += (s, e) => { move = 1; moveX = e.X; moveY = e.Y; };
            PnlUp.MouseMove += (s, e) => { if (move == 1) SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY); };
            PnlUp.MouseUp += (s, e) => { move = 0; };
        }

        void dataFull()
        {
            string sel = $"SELECT [name], size, categories, material, price, presence, nameProducer, mail, phoneNumber FROM Products, Producer";

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
        #endregion


        private void btnAdd_Click(object sender, EventArgs e)
        {
            addJewerly adJew = new addJewerly();
            adJew.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contract contract = new Contract();
            contract.Show();
        }
    }
}
