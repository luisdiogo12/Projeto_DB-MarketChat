using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MarketChat
{
    public partial class MessageForm : Form
    {
        public SqlConnection Connection { get; set; }
        public string UserNIF { get; set; }
        public string OtherNIF { get; set; }
        public string OtherName { get; set; }
        public string UserName { get; set; }

        public MessageForm(SqlConnection connection, string userNIF, string userName, string otherNIF, string otherName)
        {
            InitializeComponent();
            Connection = connection;
            UserNIF = userNIF;
            OtherNIF = otherNIF;
            OtherName = otherName;
            UserName = userName;
        }

        private void BtnClickBack(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário atual
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            LoadMessages();
        }

        private void LoadMessages()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à base de dados.");
                return;
            }

            DataTable dtMensagens = BuscarMensagens(Connection, UserNIF, OtherNIF, UserName, OtherName);
            dataGridView1.DataSource = dtMensagens;

            // Verifique se as colunas existem antes de acessá-las
            if (dataGridView1.Columns["EnviadoPor"] != null)
            {
                dataGridView1.Columns["EnviadoPor"].HeaderText = "Enviado Por";
            }

            if (dataGridView1.Columns["HoraEnviada"] != null)
            {
                dataGridView1.Columns["HoraEnviada"].HeaderText = "Hora Enviada";
            }

            if (dataGridView1.Columns["Conteudo"] != null)
            {
                dataGridView1.Columns["Conteudo"].HeaderText = "Conteúdo";
            }
        }

        public DataTable BuscarMensagens(SqlConnection connection, string userNIF, string otherNIF, string userName, string otherName)
        {
            DataTable dt = new DataTable();

            using (SqlCommand command = new SqlCommand("SELECT EnviadoPor, HoraEnviada, Conteudo FROM dbo.ObterMensagensDoChat(@UserNIF, @OtherNIF)", connection))
            {
                command.Parameters.AddWithValue("@UserNIF", userNIF);
                command.Parameters.AddWithValue("@OtherNIF", otherNIF);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            // Adicionar colunas para os nomes
            dt.Columns.Add("EnviadoPorNome", typeof(string));

            // Substituir os NIFs pelos nomes
            foreach (DataRow row in dt.Rows)
            {
                string enviadoPorNIF = row["EnviadoPor"].ToString();
                if (enviadoPorNIF == userNIF)
                {
                    row["EnviadoPorNome"] = userName;
                }
                else if (enviadoPorNIF == otherNIF)
                {
                    row["EnviadoPorNome"] = otherName;
                }
            }

            // Remover a coluna EnviadoPor original
            dt.Columns.Remove("EnviadoPor");

            // Renomear a coluna EnviadoPorNome para EnviadoPor
            dt.Columns["EnviadoPorNome"].ColumnName = "EnviadoPor";

            return dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conteudo = textBoxMensagem.Text;
            using (SqlCommand command = new SqlCommand("EXEC sp_SendMensagem @Para, @EnviadoPor, @Conteudo;", Connection))
            {
                command.Parameters.AddWithValue("@Para", OtherNIF);
                command.Parameters.AddWithValue("@EnviadoPor", UserNIF);
                command.Parameters.AddWithValue("@Conteudo", conteudo);
                object result = command.ExecuteScalar();
                LoadMessages();
            }
        }
    }
}
