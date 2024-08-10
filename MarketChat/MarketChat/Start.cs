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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarketChat
{
    public partial class Start : Form
    {
        private SqlConnection Connection;

        public Start()
        {
            InitializeComponent();
        }


        private void Start_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection("Data Source = ");
            try
            {
                Connection.Open();
                if (Connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Successful connection to database " + Connection.Database + " on the " + Connection.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Test", MessageBoxButtons.OK);
            }
        }

        private void BtnClickLogin(object sender, EventArgs e)
        {
            Login login = new Login(Connection);
            login.FormClosed += (s, args) => this.Show();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CriarConta CriarConta = new CriarConta(Connection);
            CriarConta.FormClosed += (s, args) => this.Show();
            CriarConta.Show();
            this.Hide();
        }
    }
}
