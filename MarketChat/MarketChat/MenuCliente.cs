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

namespace MarketChat
{
    public partial class MenuCliente : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }

        public MenuCliente(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MenuCliente_Load(object sender, EventArgs e)
        {

        }

        private void BtnClickView(object sender, EventArgs e)
        {
            ViewItemsClient viewItems = new ViewItemsClient(Connection, UserNIF);
            viewItems.FormClosed += (s, args) => this.Show();
            viewItems.Show();
            this.Hide();
        }

        private void BtnClickChat(object sender, EventArgs e)
        {
            Chat chat = new Chat(Connection, UserNIF);
            chat.FormClosed += (s, args) => this.Show();
            chat.Show();
            this.Hide();
        }


        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClickProfile(object sender, EventArgs e)
        {
            Profile profile = new Profile(Connection, UserNIF);
            profile.FormClosed += (s, args) => this.Show();
            profile.Show();
            this.Hide();
        }

        private void MenuCliente_Load_1(object sender, EventArgs e)
        {

        }
    }
}
