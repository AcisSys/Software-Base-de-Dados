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

        static readonly string caminho = @"Provider = Microsoft.ACE.OLEDB.12.0;
                        Data Source = WORK2GOData.accdb;
        Jet OLEDB:Database Password = ogednom ";

        // Conexão

        public readonly OleDbConnection connection = new OleDbConnection(caminho);



        // String publica para dar a conhecer a table que está a ser visualisada

        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Descricao { get; set; }


        private void Teams_Load(object sender, EventArgs e)
        {
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

                // Disable campo ID

                maskedTextBox1.ReadOnly = true;
                maskedTextBox2.Select();
                maskedTextBox1.Enabled = false;
            }
            else
            {
                button1.Text = "Modificar";
                maskedTextBox1.ReadOnly = true;
                maskedTextBox2.Select();
                maskedTextBox1.Enabled = false;
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Descricao;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Tipo == "Add")
            {
                string querry = "INSERT INTO tab_teams (ID, Descricao)" +
                        "VALUES (@ID, @Descricao)";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@Descricao",
                    OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                // Ver documentação da linha 166 - 196

                string querry = "UPDATE tab_teams  SET Descricao = @Descricao where ID = "
                    + maskedTextBox1.Text;
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@Descricao",
                    OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel modificar dados\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados modificados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";

        }


    }
}
