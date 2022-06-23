using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Agend : Form
    {
        public Agend()
        {
            InitializeComponent();
        }
        OleDbDataAdapter adapter;
        string query;
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string Idequipa { get; set; }
        public string Idtask { get; set; }
        DataSet ds = new DataSet();
        DataSet dset = new DataSet();
        int maxid;
        int currentid;
        OleDbCommand oleDbCommand;
        private void Agend_Load(object sender, EventArgs e)
        {
            // Verify connection.
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
            // Vai buscar os Dados para as MultiColumnComboBox
            // Bind dos valores com as ComboBox, e define o valor a ser mostrado
            query = "SELECT ID AS Id, Descricao AS Descrição FROM tab_teams";
            adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dset, "idteam");
            DataTable dataTable = dset.Tables["idteam"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";
            query = "SELECT ID AS Id, Descricao AS Descrição FROM tab_tasks";
            adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(ds, "idtask");
            DataTable dataTable1 = ds.Tables["idtask"];
            sfComboBox2.DataSource = dataTable1;
            sfComboBox2.DisplayMember = "ID";

            sfComboBox1.Text = Idequipa;
            sfComboBox2.Text = Idtask;
            // Condition add data.
            if (Tipo == "Add")
            {
                query = "SELECT MAX (ID) FROM tab_agend";
                oleDbCommand = new OleDbCommand(query, connection);
                maxid = (int)oleDbCommand.ExecuteScalar();
                currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            // Condition modify data.
            else
            {
                maskedTextBox1.Text = Id.ToString();
            }
            // Torna o ID Imutável pelo utilizador
            maskedTextBox1.Enabled = false;
            maskedTextBox1.ReadOnly = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // Check if all fields are used.
            if ((sfComboBox1.SelectedItem == null) || (sfComboBox2.SelectedItem == null))
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                if (sfComboBox1.SelectedItem == null)
                {
                    toolStripButton1.ToolTipText = "Verifique o preenchimento de todos os campos antes de validar dados";
                }
                // Condition add data.
                if (Tipo == "Add")
                {
                    query = "INSERT INTO tab_agend (ID, IDEquipa, IDTask)" +
                          "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox2.Text;
                }
                // Condition modify data.
                else
                {
                    query = "UPDATE tab_agend  SET IDEquipa = @IDEquipa, IDTask = @IDTask where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox2.Text;
                }
                try
                // Execute command.
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
                maskedTextBox1.Text = "";
                sfComboBox1.Text = "";
                sfComboBox2.Text = "";
                this.Close();
            }
        }
        private void ToolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
