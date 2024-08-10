using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketChat
{
    public partial class Chat : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }

        public string UserName { get; set; }
        public string OtherName { get; set; }

        public string OtherNIF { get; set; }

        public Chat(SqlConnection connection, string userNIF)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
            this.Load += new EventHandler(Chat_Load);
        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadChats();
                dataGridConversas.CellDoubleClick += DataGridViewConversas_CellDoubleClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar chats: " + ex.Message);
            }
        }

        private void LoadChats()
        {
            try
            {
                if (Connection == null)
                {
                    MessageBox.Show("Erro: A conexão é nula.");
                    return;
                }

                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();
                }

                DataTable dtConversas = BuscarConversas(Connection, UserNIF);
                if (dtConversas == null || dtConversas.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhuma conversa encontrada.");
                }
                else
                {
                    // Adicionar colunas para os nomes dos utilizadores
                    dtConversas.Columns.Add("Nome_A", typeof(string));
                    dtConversas.Columns.Add("Nome_B", typeof(string));

                    foreach (DataRow row in dtConversas.Rows)
                    {
                        string chatANIF = row["Chat_A_NIF"].ToString();
                        string chatBNIF = row["Chat_B_NIF"].ToString();

                        row["Nome_A"] = GetUserName(chatANIF);
                        row["Nome_B"] = GetUserName(chatBNIF);
                    }

                    // Adicionar uma nova coluna para exibir o nome do outro utilizador
                    dtConversas.Columns.Add("OtherUserName", typeof(string));
                    dtConversas.Columns.Add("OtherNIF", typeof(string));

                    foreach (DataRow row in dtConversas.Rows)
                    {
                        string chatANIF = row["Chat_A_NIF"].ToString();
                        string chatBNIF = row["Chat_B_NIF"].ToString();

                        if (chatANIF == UserNIF)
                        {
                            row["OtherUserName"] = row["Nome_B"];
                            row["OtherNIF"] = chatBNIF;
                        }
                        else
                        {
                            row["OtherUserName"] = row["Nome_A"];
                            row["OtherNIF"] = chatANIF;
                        }
                    }

                    // Remover as colunas Nome_A e Nome_B, Chat_A_NIF, Chat_B_NIF
                    dtConversas.Columns.Remove("Nome_A");
                    dtConversas.Columns.Remove("Nome_B");
                    dtConversas.Columns.Remove("Chat_A_NIF");
                    dtConversas.Columns.Remove("Chat_B_NIF");

                    dataGridConversas.DataSource = dtConversas;
                    dataGridConversas.Columns["OtherUserName"].HeaderText = "Outro Utilizador";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar conversas: " + ex.Message);
            }
        }

        public DataTable BuscarConversas(SqlConnection connection, string userNIF)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.ObterChatsDoUtilizador(@UserNIF)", connection))
                {
                    command.Parameters.AddWithValue("@UserNIF", userNIF);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar conversas: " + ex.Message);
                return null;
            }
        }

        private void DataGridViewConversas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se um índice de linha válido foi clicado
            {
                DataGridViewRow row = dataGridConversas.Rows[e.RowIndex];
                string otherUserName = row.Cells["OtherUserName"].Value.ToString();
                string otherNIF = row.Cells["OtherNIF"].Value.ToString();

                // Utilize as funções para obter os nomes dos utilizadores
                string userName = GetUserName(UserNIF);

                MessageForm messageForm = new MessageForm(Connection, UserNIF, userName, otherNIF, otherUserName);
                messageForm.FormClosed += (s, args) => this.Show();
                messageForm.Show();
                this.Hide();
            }
        }

        private string GetUserName(string nif)
        {
            string userName = string.Empty;

            using (SqlCommand command = new SqlCommand("SELECT Nome FROM dbo.ObterInformacaoUtilizador(@NIF)", Connection))
            {
                command.Parameters.AddWithValue("@NIF", nif);

                try
                {
                    if (Connection.State == System.Data.ConnectionState.Closed)
                    {
                        Connection.Open();
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        userName = reader["Nome"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o nome do utilizador: " + ex.Message);
                }
            }

            return userName;
        }

        private void Chat_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridConversas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
