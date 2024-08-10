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
    public partial class ViewItemsFuncionario : Form
    {
        public SqlConnection Connection { get; set; }
        public ViewItemsFuncionario(SqlConnection connection)
        {
            InitializeComponent();
            Connection = connection;
            this.Load += new EventHandler(ViewItemsFuncionario_Load);

        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewItemsFuncionario_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à Base de Dados");
                return;
            }

            DataTable dtProdutos = BuscarProdutos(Connection);

            if (dtProdutos.Rows.Count > 0)
            {
                dataGridViewProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridViewProdutos.DataSource = dtProdutos;
                dataGridViewProdutos.AutoGenerateColumns = true;

            }
            else
            {
                MessageBox.Show("Não há produtos disponíveis.");
            }
        }






        public DataTable BuscarProdutos(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Produto", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        private void ViewItemsFuncionario_Load_1(object sender, EventArgs e)
        {

        }
    }
}
