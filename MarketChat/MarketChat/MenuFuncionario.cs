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
    public partial class MenuFuncionario : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }

        public MenuFuncionario(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
        }

        private void MenuFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void BtnClickGerir(object sender, EventArgs e)
        {
            GerirFuncionarios gerirFuncionarios = new GerirFuncionarios(Connection, UserNIF);
            gerirFuncionarios.FormClosed += (s, args) => this.Show();
            gerirFuncionarios.Show();
            this.Hide();
        }

        private void BtnClickList(object sender, EventArgs e)
        {
            ListItemFinal listItemFinal = new ListItemFinal(Connection, UserNIF);
            listItemFinal.FormClosed += (s, args) => this.Show();
            listItemFinal.Show();
            this.Hide();
        }

        private void BtnClickChat(object sender, EventArgs e)
        {
            Chat chat = new Chat(Connection, UserNIF);
            chat.FormClosed += (s, args) => this.Show();
            chat.Show();
            this.Hide();
        }

        private void BtnClickStats(object sender, EventArgs e)
        {

        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClickView(object sender, EventArgs e)
        {
            ViewItemsFuncionario viewItems = new ViewItemsFuncionario(Connection);
            viewItems.FormClosed += (s, args) => this.Show();
            viewItems.Show();
            this.Hide();

        }
    }
}
