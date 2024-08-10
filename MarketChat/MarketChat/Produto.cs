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
    public partial class Produto : Form
    {
        public SqlConnection Connection { get; set; }
        public string ProdutoID { get; set; }
        public string VendedorNIF { get; set; }
        public Produto(SqlConnection connection, string produtoID, string vendedorNIF)
        {
            InitializeComponent();
            Connection = connection;
            ProdutoID = produtoID;
            VendedorNIF = vendedorNIF;
            this.Load += new EventHandler(Produto_Load);
        }

        //ver perfil vendedor
        private void button1_Click(object sender, EventArgs e) 
        {
            VendedorProfile vendedorProfile = new VendedorProfile(Connection, VendedorNIF);
            vendedorProfile.FormClosed += (s, args) => this.Show();
            vendedorProfile.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //iniciar/abrir chat com vendedor
        private void button2_Click(object sender, EventArgs e)
        {
            // verificar se ja existe chat com vendedor
            // se sim, abrir chat se não, criar chat
            // ir para o chat
        }
        // abrir chat com especialista
        private void button3_Click(object sender, EventArgs e)
        {
            // verificar se ja existe chat com algum especialista (tem que fazer a pesquisa pela tabela dos seus chats join com a tabela de especialistas para ver se tem algum nif correspondente)
            // se sim, abrir chat se não, criar chat
            // ir para o chat
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Produto_Load(object sender, EventArgs e)
        {
            CarregarDetalhesProduto();
        }
        private void CarregarDetalhesProduto()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à Base de Dados");
                return;
            }

            try
            {
                // Carregar detalhes do produto
                using (SqlCommand command = new SqlCommand("SELECT NomeProduto,VendedorNIF , Preco, NomeCaracteristica, ValorCaracteristica FROM vw_ProdutosCaracteristicas WHERE ProdutoID = @ProdutoID", Connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", ProdutoID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            // Atualizar o label com o nome do produto
                            label1.Text = dt.Rows[0]["NomeProduto"].ToString();

                            // Adicionar o preço como uma característica
                            DataTable dtCaracteristicas = new DataTable();
                            dtCaracteristicas.Columns.Add("NomeCaracteristica", typeof(string));
                            dtCaracteristicas.Columns.Add("ValorCaracteristica", typeof(string));

                            DataRow precoRow = dtCaracteristicas.NewRow();
                            precoRow["NomeCaracteristica"] = "Preço";
                            precoRow["ValorCaracteristica"] = dt.Rows[0]["Preco"].ToString();
                            dtCaracteristicas.Rows.Add(precoRow);

                            foreach (DataRow row in dt.Rows)
                            {
                                DataRow newRow = dtCaracteristicas.NewRow();
                                newRow["NomeCaracteristica"] = row["NomeCaracteristica"];
                                newRow["ValorCaracteristica"] = row["ValorCaracteristica"];
                                dtCaracteristicas.Rows.Add(newRow);
                            }

                            dataGridView1.DataSource = dtCaracteristicas;
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar detalhes do produto: " + ex.Message);
            }
        }
    }
}
