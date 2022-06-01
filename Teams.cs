using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Teams : Form
    {
        public Teams()
        {
            InitializeComponent();
        }

        // String do caminho do ficheiro

        static readonly string caminho = Tables.Caminho;

        // Conexão

        public readonly OleDbConnection connection = new OleDbConnection(caminho);



        // String publica para dar a conhecer a table que está a ser visualisada

        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Descricao { get; set; }


        private void Teams_Load(object sender, EventArgs e)
        {
            // Verifica conexao
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel connectar á base de dados\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Tipo == "Add")
            {
                button1.Text = "Guardar";

                // ID é automatico


                string comand = "SELECT MAX (ID) FROM tab_teams";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();

            }
            else
            {
                button1.Text = "Modificar";
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Descricao;

            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.Select();
            maskedTextBox1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "")
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {


                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                {
                    // Querry e parametros para adicionar dados
                    string querry = "INSERT INTO tab_teams (ID, Descricao)" +
                            "VALUES (@ID, @Descricao)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Descricao",
                        OleDbType.LongVarChar).Value = maskedTextBox2.Text;

                }
                else
                {
                    // Querry e parametros para modificar dados

                    string querry = "UPDATE tab_teams  SET Descricao = @Descricao where ID = "
                        + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Descricao",
                        OleDbType.LongVarChar).Value = maskedTextBox2.Text;

                }
                try
                {
                    //Executa comando e envia feedback ao user
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel atualizar dados\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados atualizados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                this.Close();
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
