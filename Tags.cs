using System;
using System.Data;
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
        string query;
        private void Tags_Load(object sender, EventArgs e)
        {
            // Check connection.
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
                // Add data.
                query = "SELECT MAX (ID) FROM tab_tags";
                OleDbCommand oleDbCommand = new OleDbCommand(query, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
                
            }
            else
            {
                // Change data.
                maskedTextBox1.Text = Id.ToString();
                maskedTextBox2.Text = Ref.ToString();
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            connection.Close();
            button1.Select();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
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
            // Checks data type.
            if (int.TryParse(maskedTextBox2.Text, out _) == false)
            {
                sfToolTip1.Show("Verifique se todos os campos estão \ncorretos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                // Add data.
                {
                    query = "INSERT INTO tab_tags (ID, Ref, taken) " +
                               "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@Taken",
                        OleDbType.LongVarChar).Value = "Não";
                }
                else
                // Change data.
                {
                    query = "SELECT ID FROM tab_tasks WHERE RefTag = " + maskedTextBox2.Text;
                    oleDbCommand = new OleDbCommand(query, connection);
                    string taken = Convert.ToString(oleDbCommand.ExecuteScalar());
                    if (taken != "")
                    {
                        taken = "Sim";
                    }
                    else
                    {
                        taken = "Não";
                    }
                    query = "UPDATE tab_tags  SET Ref = @Ref," +
                       " taken = @taken where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(query, connection);
                    // Check REF taken or not taken.
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
                if (connection.State == ConnectionState.Closed)
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
                // Execute command.
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
                connection.Close();
                this.Close();
            }
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
