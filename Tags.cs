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
        readonly OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int Id { get; set; }
        public float Ref { get; set; }
        public bool Taken { get; set; }
        string querry;
        private void Tags_Load(object sender, EventArgs e)
        {
            // check connection
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
                // add data
                querry = "SELECT MAX (ID) FROM tab_tags";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                //change data
                maskedTextBox1.Text = Id.ToString();
                maskedTextBox2.Text = Ref.ToString();
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            button1.Select();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // checks data type
            if (int.TryParse(maskedTextBox2.Text, out _) == false)
            {
                sfToolTip1.Show("Verifique se todos os campos estão \ncorretos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                //add data
                {
                    querry = "INSERT INTO tab_tags (ID, Ref, taken) " +
                               "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@Taken",
                        OleDbType.LongVarChar).Value = "Não";
                }
                else
                // change data
                {
                    querry = "SELECT ID FROM tab_tasks WHERE RefTag = " + maskedTextBox2.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    string taken = Convert.ToString(oleDbCommand.ExecuteScalar());
                    if (taken != "")
                    {
                        taken = "Sim";
                    }
                    else
                    {
                        taken = "Não";
                    }
                    querry = "UPDATE tab_tags  SET Ref = @Ref," +
                       " taken = @taken where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    // check REF taken or not taken
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    if (Taken == true)
                    {
                        oleDbCommand.Parameters.Add("@taken", OleDbType.LongVarChar).Value = taken;
                    }
                    else
                    {
                        oleDbCommand.Parameters.Add("@taken", OleDbType.LongVarChar).Value = taken;
                    }
                }
                // execute command
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
