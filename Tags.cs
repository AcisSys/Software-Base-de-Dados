using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Tags : Form
    {
        public Tags()
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
        public string Ref { get; set; }
        public bool Taken { get; set; }
        string querry;

        private void Tags_Load(object sender, EventArgs e)
        {
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
            {
                // ID é automatico
                querry = "SELECT MAX (ID) FROM tab_tags";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Ref;
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            button1.Select();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(maskedTextBox2.Text, out _) == false)
            {
                sfToolTip1.Show("Verifique se todos os campos estão \ncorretos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                {
                    // querry para inserir dados
                    querry = "INSERT INTO tab_tags (ID, Ref, taken) " +
                               "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@Taken",
                        OleDbType.LongVarChar).Value = "Não";
                }
                else
                {
                    querry = "UPDATE tab_tags  SET Ref = @Ref," +
                       " taken = @taken where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@taken", OleDbType.LongVarChar).Value = "Não";
                }
                // tenta executar o comando e envia mensagem de erro / sucesso
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                this.Close();
            }
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
