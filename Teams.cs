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

        readonly OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Descricao { get; set; }
        string querry;
        private void Teams_Load(object sender, EventArgs e)
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
                button1.Text = "Guardar";
                querry = "SELECT MAX (ID) FROM tab_teams";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
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
                    querry = "INSERT INTO tab_teams (ID, Descricao)" +
                           "VALUES (@ID, @Descricao)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Descricao",
                        OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                }
                else
                {
                    querry = "UPDATE tab_teams  SET Descricao = @Descricao where ID = "
                       + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Descricao",
                        OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                }
                try
                {
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
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
