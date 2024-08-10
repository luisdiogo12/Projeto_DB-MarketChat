using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketChat
{
    public partial class ListItem : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }

        public ListItem(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
        }

        private void BtnClickSubmit(object sender, EventArgs e)
        {
            // Obtém os valores inseridos pelo usuário
            string productName = textBox1.Text;
            string productPrice = textBox3.Text;

            // Insere o produto na base de dados
            InsertProduct(productName, productPrice, UserNIF);
        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = textBox1.Text;
            string productPrice = textBox3.Text; 
            string userNIF = UserNIF; // Substitua pelo NIF do usuário atual ou pegue-o de onde ele está armazenado

            InsertProduct(productName, productPrice, userNIF);
        }

        private void InsertProduct(string productName, string productPrice, string userNIF)
        {
            try
            {
                // Certifique-se de converter o NIF do usuário para um inteiro
                if (!int.TryParse(userNIF, out int vendedorNIF))
                {
                    MessageBox.Show("Erro: NIF do vendedor inválido.");
                    return;
                }

                // Cria uma nova conexão se não estiver aberta
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }

                // Define o nome da stored procedure
                string storedProcedureName = "InserirProduto";

                // Cria um comando SQL com a stored procedure e a conexão
                using (SqlCommand command = new SqlCommand(storedProcedureName, Connection))
                {
                    // Define o tipo de comando como uma stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Adiciona os parâmetros à stored procedure
                    command.Parameters.AddWithValue("@VendedorNIF", vendedorNIF);
                    command.Parameters.AddWithValue("@Nome", productName);
                    command.Parameters.AddWithValue("@Preco", productPrice);

                    // Executa a stored procedure
                    command.ExecuteNonQuery();

                    MessageBox.Show("Produto adicionado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
            }
            
        }


    }
}
