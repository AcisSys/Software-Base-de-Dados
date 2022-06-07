using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Places : Form
    {
        public Places()
        {
            InitializeComponent();
        }
        static readonly string caminho = Tables.Caminho;
        public readonly OleDbConnection connection = new OleDbConnection(caminho);
        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Localizacao { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        string querry;
        private void Places_Load(object sender, EventArgs e)
        {
            // verifica conexao
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.ConnectionString = Tables.Caminho;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel connectar á base de dados\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Tipo == "Add")
            // Querry para adicionar dados
            {
                querry = "SELECT MAX (ID) FROM tab_places";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Localizacao;
                maskedTextBox3.Text = X;
                maskedTextBox4.Text = Y;
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.Select();
            maskedTextBox1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Verifica o preenchimento de todos os campos
            if (maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "")
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                // Querry para adicionar dados
                if (Tipo == "Add")
                {
                    querry = "INSERT INTO tab_places (ID, Localizacao, X, Y)" +
                      "VALUES (@ID, @Localizacao, @X, @Y)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Localizacao",
                        OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@X", OleDbType.Integer).Value = maskedTextBox3.Text;
                    oleDbCommand.Parameters.Add("@Y", OleDbType.Integer).Value = maskedTextBox4.Text;
                }
                // Querry para modificar dados
                else
                {
                    querry = "UPDATE tab_places  SET Localizacao = @Localizacao, X = @X," +
                        " Y = @Y where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Localizacao",
                        OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@X", OleDbType.Integer).Value = maskedTextBox3.Text;
                    oleDbCommand.Parameters.Add("@Y", OleDbType.Integer).Value = maskedTextBox4.Text;
                }
                // Tenta executar o comando e envia feedback ao user
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                maskedTextBox3.Text = "";
                maskedTextBox4.Text = "";
                this.Close();
            }
        }

        private void ToolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}