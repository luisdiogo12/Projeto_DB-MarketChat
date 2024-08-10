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
    public partial class CriarConta : Form
    {
        public SqlConnection Connection { get; set; }
        public CriarConta(SqlConnection connection)
        {
            InitializeComponent();
            Connection = connection;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            //nif
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //nome
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //email
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //password
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //numero de telefone
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //rua
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //localidade
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //codigo postal
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //criar conta como comprador
            CriarContaUtilizador(true, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //criar conta como comprador e vendedor
            CriarContaUtilizador(true, true);
        }

        private void CriarContaUtilizador(bool isComprador, bool isVendedor)
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à Base de Dados");
                return;
            }

            if (string.IsNullOrEmpty(textBoxEmail.Text) ||
                string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text) ||
                string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Erro: Todos os campos são obrigatórios");
                return;
            }

            try
            {
                using (SqlCommand command = new SqlCommand("sp_InsertCliente", Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NIF", Convert.ToInt32(textBoxEmail.Text));
                    command.Parameters.AddWithValue("@Nome", textBox1.Text);
                    command.Parameters.AddWithValue("@Email", textBox2.Text);
                    command.Parameters.AddWithValue("@Hash", textBox3.Text);
                    command.Parameters.AddWithValue("@N_telemovel", Convert.ToInt32(textBox4.Text));
                    command.Parameters.AddWithValue("@Rua", textBox5.Text);
                    command.Parameters.AddWithValue("@Localidade", textBox6.Text);
                    command.Parameters.AddWithValue("@Cod_Postal", textBox7.Text);
                    command.Parameters.AddWithValue("@IsComprador", isComprador ? 1 : 0);
                    command.Parameters.AddWithValue("@IsVendedor", isVendedor ? 1 : 0);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Conta criada com sucesso!");
                this.Close(); // Fechar a janela após a criação da conta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar conta: " + ex.Message);
            }
        }
    }
}
