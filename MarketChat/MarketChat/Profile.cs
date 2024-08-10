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
    public partial class Profile : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }

        public Profile(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }
    }
}
