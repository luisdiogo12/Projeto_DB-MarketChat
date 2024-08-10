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
    public partial class ViewItemsClient : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }
        private List<string> appliedFilters;

        public ViewItemsClient(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
            this.Load += new EventHandler(ViewItemsClient_Load);
            appliedFilters = new List<string>();
        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewItemsClient_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadAvailableFilters();
            LoadAppliedFilters();
            dataGridViewProdutos.CellDoubleClick += dataGridViewProdutos_CellDoubleClick;
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


        private void LoadAvailableFilters()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à Base de Dados");
                return;
            }

            DataTable dtFiltros = BuscarFiltros(Connection);

            if (dtFiltros.Rows.Count > 0)
            {
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.DataSource = dtFiltros;
                dataGridView2.AutoGenerateColumns = true;
            }
            else
            {
                MessageBox.Show("Não há filtros disponíveis.");
            }
        }

        private void LoadAppliedFilters()
        {
            DataTable dtAppliedFilters = new DataTable();
            dtAppliedFilters.Columns.Add("Filtro");

            foreach (var filtro in appliedFilters)
            {
                DataRow row = dtAppliedFilters.NewRow();
                row["Filtro"] = filtro;
                dtAppliedFilters.Rows.Add(row);
            }

            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.DataSource = dtAppliedFilters;
            dataGridView3.AutoGenerateColumns = true;
        }

        private DataTable BuscarProdutos(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.ObterTodosOsProdutos()", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        private DataTable BuscarFiltros(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT NomeFiltro, ValorFiltro FROM vw_FiltrosValores ORDER BY NomeFiltro ASC, ValorFiltro ASC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        private void BtnClickChat(object sender, EventArgs e)
        {
            Chat chat = new Chat(Connection, UserNIF);
            chat.FormClosed += (s, args) => this.Show();
            chat.Show();
            this.Hide();
        }

        private void ViewItemsClient_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridViewProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //display produtos
        {
            if (e.RowIndex >= 0) // Verifica se um índice de linha válido foi clicado
            {
                DataGridViewRow row = dataGridViewProdutos.Rows[e.RowIndex];
                string produtoID = row.Cells["ProdutoID"].Value.ToString();
                string vendedorNIF = row.Cells["VendedorNIF"].Value.ToString();

                Produto produtoForm = new Produto(Connection, produtoID, vendedorNIF);
                produtoForm.FormClosed += (s, args) => this.Show();
                produtoForm.Show();
                this.Hide();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Display dos filtros disponiveis
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Disply dos filtros aplicados
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filtroNome = textBox1.Text;
            string filtroValor = textBox2.Text;

            if (!string.IsNullOrWhiteSpace(filtroNome) && !string.IsNullOrWhiteSpace(filtroValor))
            {
                string filtro = $"{filtroNome}:{filtroValor}";
                if (!appliedFilters.Contains(filtro))
                {
                    appliedFilters.Add(filtro);
                    LoadAppliedFilters();
                    AplicarFiltros();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string produtoID = textBoxEmail.Text;

            if (!string.IsNullOrWhiteSpace(produtoID))
            {
                DataTable dtProduto = BuscarProdutoPorID(Connection, produtoID);

                if (dtProduto.Rows.Count > 0)
                {
                    dataGridViewProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridViewProdutos.DataSource = dtProduto;
                    dataGridViewProdutos.AutoGenerateColumns = true;
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //limpar filtro
        {
            appliedFilters.Clear();
            LoadAppliedFilters();
            LoadItems();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // nome do filtro
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // valor do filtro
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            // id do produto
        }

        private DataTable BuscarProdutoPorID(SqlConnection connection, string produtoID)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Produto WHERE ProdutoID = @ProdutoID", connection))
            {
                command.Parameters.AddWithValue("@ProdutoID", produtoID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        private void AplicarFiltros()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à Base de Dados");
                return;
            }

            string filtros = string.Join(",", appliedFilters);
            DataTable dtProdutos = BuscarProdutosPorFiltros(Connection, filtros);

            if (dtProdutos.Rows.Count > 0)
            {
                dataGridViewProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridViewProdutos.DataSource = dtProdutos;
                dataGridViewProdutos.AutoGenerateColumns = true;
            }
            else
            {
                MessageBox.Show("Não há produtos que correspondam aos filtros aplicados.");
            }
        }

        private DataTable BuscarProdutosPorFiltros(SqlConnection connection, string filtros)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.PesquisaProdutos(@CaracteristicasValores)", connection))
            {
                command.Parameters.AddWithValue("@CaracteristicasValores", filtros);
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
