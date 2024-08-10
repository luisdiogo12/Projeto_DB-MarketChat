using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System;
using System.Data.SqlClient;
using System.Data;

namespace MarketChat
{
    public partial class Login : Form
    {
        private SqlConnection Connection { get; set; }
        public Login(SqlConnection connection)
        {
            InitializeComponent();
            Connection = connection;
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnClickLogin(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            var validationResult = ValidateUser(email, password);
            if (validationResult != null)
            {
                int? userNIF = validationResult.Item1;
                bool isEmployee = validationResult.Item2;

                Form targetForm;
                if (isEmployee)
                {
                    targetForm = new MenuFuncionario(Connection, userNIF.Value.ToString()); // Formulário para funcionários
                }
                else
                {
                    targetForm = new MenuCliente(Connection, userNIF.Value.ToString()); // Formulário para clientes
                }

                targetForm.FormClosed += (s, args) => this.Show();
                targetForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK);
            }
        }


        private Tuple<int?, bool> ValidateUser(string email, string hash)
        {
            if (Connection == null || Connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Connection to database is not open.", "Connection Error", MessageBoxButtons.OK);
                return null;
            }

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT NIF FROM Utilizador WHERE Email = @Email AND Hash = @Hash", Connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Hash", hash);

                    object result = command.ExecuteScalar();
                    int? nif = result != null ? (int?)result : null;
                    bool isEmployee = nif.HasValue && CheckIfIsEmployee(nif.Value);

                    return Tuple.Create(nif, isEmployee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while validating user: " + ex.Message, "Validation Error", MessageBoxButtons.OK);
                return null;
            }
        }

        private bool CheckIfIsEmployee(int nif)
        {
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Funcionario WHERE NIF = @NIF", Connection))
            {
                command.Parameters.AddWithValue("@NIF", nif);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }


        private void BtnClickClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
