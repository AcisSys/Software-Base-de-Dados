using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Tasks : Form
    {
        public Tasks()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string IdPlace { get; set; }
        public bool Active { get; set; }
        string oldref;
        public string RefTag { get; set; }
        string query;
        private void Tasks_Load(object sender, EventArgs e)
        {

            // Check connection.
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
            if (Tipo == "Add")
            // Add data.
            {
                string comand = "SELECT MAX (ID) FROM tab_tasks";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            // Modify data.
            {
                maskedTextBox1.Text = Id.ToString();
                maskedTextBox2.Text = Descricao;
                if (Active == true)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            DataSet dset = new DataSet();
            OleDbDataAdapter adapter;
            query = "SELECT ID AS Id, Localizacao AS Localização FROM tab_places";
            adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";
            query = "SELECT Ref AS Etiquetas FROM tab_tags WHERE taken = 'Não'";
            adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dset, "type");
            dataTable = dset.Tables["type"];
            sfComboBox2.DataSource = dataTable;
            sfComboBox2.DisplayMember = "Ref";
            sfComboBox1.Text = IdPlace;
            sfComboBox2.Text = RefTag;
            oldref = RefTag;
            maskedTextBox1.ReadOnly = true;
            Button1.Select();
            maskedTextBox1.Enabled = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // Verifies entries.
            if ((maskedTextBox2.Text == "") || (sfComboBox1.SelectedItem == null))
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                string active;
                if (checkBox1.Checked == true)
                {
                    active = "Sim";
                }
                else
                {
                    active = "Não";
                }
                // Add data.
                if (Tipo == "Add")
                {
                    query = "INSERT INTO tab_tasks (ID, Descricao, IDPlace, Active, RefTag)" +
                            "VALUES (@ID, @Descricao, @IDPlace, @Active, @RefTag)";
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Descricao", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDPlace", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = active;
                    oleDbCommand.Parameters.Add("@RefTag", OleDbType.Integer).Value = sfComboBox2.Text;
                }
                else
                // Modify data.
                {
                    query = "UPDATE tab_tasks SET  Descricao = @Descricao, IDPlace = @IDPlace , Active = @Active , RefTag = @RefTag" +
                       " WHERE ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@Descricao", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDPlace", OleDbType.Integer).Value = int.Parse(sfComboBox1.Text);
                    oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = active;
                    oleDbCommand.Parameters.Add("@RefTag", OleDbType.Integer).Value = int.Parse(sfComboBox2.Text);
                }
                try
                {
                    // Changes tag taken if needed on tab_tags.
                    // Execute commands.
                    oleDbCommand.ExecuteNonQuery();
                    if (oldref != sfComboBox2.Text)
                    {
                        query = "UPDATE tab_tags SET taken = @taken WHERE Ref = " + oldref;
                        OleDbCommand oleDb = new OleDbCommand(query, connection);
                        oleDb.Parameters.Add("@taken", OleDbType.LongVarChar).Value = "Não";
                        oleDb.ExecuteNonQuery();
                    }
                    query = "UPDATE tab_tags SET taken = @taken WHERE Ref = " + sfComboBox2.Text;
                    OleDbCommand ole = new OleDbCommand(query, connection);
                    ole.Parameters.Add("@taken", OleDbType.LongVarChar).Value = "Sim";
                    ole.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel modificar dados\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados modificados com sucesso", "",
                    MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                maskedTextBox1.Text = "";
                sfComboBox1.Text = "";
                sfComboBox2.Text = "";
                this.Close();
            }
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
