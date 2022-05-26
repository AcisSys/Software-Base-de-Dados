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

        // String do caminho do ficheiro

        static readonly string caminho = @"Provider = Microsoft.ACE.OLEDB.12.0;
                        Data Source = WORK2GOData.accdb;
        Jet OLEDB:Database Password = ogednom ";

        // Conexão

        public readonly OleDbConnection connection = new OleDbConnection(caminho);

        // DataSet para as tabelas



        // Adaptador para o DataSet




        // String publica para dar a conhecer a table que está a ser visualisada

        public string Tipo { get; set; }

        // Int / String para cada campo da tabela
        public int ID { get; set; }
        public string Localizacao { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    

        private void Places_Load(object sender, EventArgs e)
        {
            // verifica conexao
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


                string comand = "SELECT MAX (ID) FROM tab_places";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();

                // Disable campo ID

                maskedTextBox1.ReadOnly = true;
                maskedTextBox1.Enabled = false;
            }
            else
            {
                button1.Text = "Modificar";
                maskedTextBox1.ReadOnly = true;
                maskedTextBox3.Select();
                maskedTextBox1.Enabled = false;
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Localizacao;
                maskedTextBox3.Text = X;
                maskedTextBox4.Text = Y;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (Tipo == "Add")
            {
                // Cria uma nova querry de acordo com a tabela e parametros da mesma
                string querry = "INSERT INTO tab_places (ID, Localizacao, X, Y)" +
                   "VALUES (@ID, @Localizacao, @X, @Y)";
                // Cria um comando para executar a Querry, dados os parametros necessários
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@Localizacao",
                    OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@X", OleDbType.Integer).Value = maskedTextBox3.Text;
                oleDbCommand.Parameters.Add("@Y", OleDbType.Integer).Value = maskedTextBox4.Text;

                // Tenta executar o comando
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    // Envia mensagem de erro caso necessário
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Para o código
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else
            {
                // Ver documentação da linha 166 - 196

                string querry = "UPDATE tab_places  SET Localizacao = @Localizacao, X = @X," +
                     " Y = @Y where ID = " + maskedTextBox1.Text;
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@Localizacao",
                    OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@X", OleDbType.Integer).Value = maskedTextBox3.Text;
                oleDbCommand.Parameters.Add("@Y", OleDbType.Integer).Value = maskedTextBox4.Text;
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel modificar dados\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados modificados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }

            // apaga os valores de todos os campos
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";

        }
    }
}