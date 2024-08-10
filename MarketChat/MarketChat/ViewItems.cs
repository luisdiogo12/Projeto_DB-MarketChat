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
    public partial class ViewItems : Form
    {
        public SqlConnection Connection { get; set; }
        public ViewItems(SqlConnection connection)
        {
            InitializeComponent();
            Connection = connection;
        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewItems_Load(object sender, EventArgs e)
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

            // Limpa as colunas existentes para evitar duplicatas
            listViewProdutos.Columns.Clear();
            listViewProdutos.Items.Clear();

            // Adiciona as colunas se a DataTable não estiver vazia
            if (dtProdutos.Rows.Count > 0)
            {
                // Adiciona o ProdutoID como a primeira coluna e alinha à esquerda
                listViewProdutos.Columns.Add("ProdutoID", -2, HorizontalAlignment.Left);

                // Adiciona todas as outras colunas da DataTable
                foreach (DataColumn column in dtProdutos.Columns)
                {
                    if (column.ColumnName != "ProdutoID")
                    {
                        // Adiciona os outros campos e alinha à esquerda
                        listViewProdutos.Columns.Add(column.ColumnName, -2, HorizontalAlignment.Left);
                    }
                }
            }

            // Adiciona os itens à ListView
            foreach (DataRow row in dtProdutos.Rows)
            {
                // Cria um novo item para cada linha na DataTable
                ListViewItem item = new ListViewItem(row["ProdutoID"].ToString()); // Adiciona o ProdutoID como o primeiro subitem
                for (int i = 1; i < dtProdutos.Columns.Count; i++)
                {
                    // Adiciona os outros valores como subitens e alinha à esquerda
                    item.SubItems.Add(row[i].ToString());
                }
                // Adiciona o item completo à ListView
                listViewProdutos.Items.Add(item);
            }

            // Ajusta a largura das colunas para exibir todo o conteúdo
            foreach (ColumnHeader column in listViewProdutos.Columns)
            {
                column.Width = -2;
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
    }
}
