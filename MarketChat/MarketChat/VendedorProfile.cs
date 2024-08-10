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
    public partial class VendedorProfile : Form
    {
        public SqlConnection Connection { get; set; }
        public string VendedorNIF { get; set; }
        public VendedorProfile(SqlConnection connection, string vendedorNIF)
        {
            InitializeComponent();
            Connection = connection;
            VendedorNIF = vendedorNIF;
            this.Load += new EventHandler(VendedorProfile_Load);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void VendedorProfile_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dados vendedor
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //nome vendedor
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //comentarios vendedor
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // dar like
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // dar dislike
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // iniciar/abrir chat com vendedor
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            // id do comentario
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // dar like ao comentario com o id na textbox
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // dar dislike ao comentario com o id na textbox
        }

        private void CarregarPerfilVendedor()
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Erro: Não foi possível conectar à Base de Dados");
                return;
            }

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM vw_Vendedores WHERE NIF = @VendedorNIF", Connection))
                {
                    command.Parameters.AddWithValue("@VendedorNIF", VendedorNIF);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        if (dt.Rows.Count > 0)
                        {
                            // Carregar dados do vendedor na DataGridView
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Vendedor não encontrado.");
                        }
                    }
                }

                // Carregar comentários do vendedor
                using (SqlCommand command = new SqlCommand("SELECT * FROM Comentario WHERE VendedorNIF = @VendedorNIF", Connection))
                {
                    command.Parameters.AddWithValue("@VendedorNIF", VendedorNIF);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dtComentarios = new DataTable();
                        dtComentarios.Load(reader);
                        dataGridView2.DataSource = dtComentarios;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar perfil do vendedor: " + ex.Message);
            }
        }
    }
}
