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
    public partial class Menu : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }

        public Menu(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClickList(object sender, EventArgs e)
        {
            ListItem listItem = new ListItem(Connection, UserNIF);
            listItem.FormClosed += (s, args) => this.Show();
            listItem.Show();
            this.Hide();
        }

        private void BtnClickView(object sender, EventArgs e)
        {
            ViewItems viewItems = new ViewItems(Connection);
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

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
