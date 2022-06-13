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
        DataSet dset = new DataSet();
        OleDbDataAdapter adapter;
        string querry;
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string Idequipa { get; set; }
        public string Idtask { get; set; }
        private void Agend_Load(object sender, EventArgs e)
        {
            // verifica conexao
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
            {
                string comand = "SELECT MAX (ID) FROM tab_agend";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                maskedTextBox1.Text = Id.ToString();
                querry = "SELECT ID FROM tab_teams";
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(dset, "idteam");
                DataTable dataTable = dset.Tables["idteam"];

                /*
                 * codigo em https://stackoverflow.com/questions/22970418/copy-c-sharp-datatable-and-convert-all-values-to-string
                 */
                DataTable dtClone = dataTable.Clone(); //just copy structure, no data
                for (int i = 0; i < dtClone.Columns.Count; i++)
                {
                    if (dtClone.Columns[i].DataType != typeof(string))
                        dtClone.Columns[i].DataType = typeof(string);
                }

                foreach (DataRow dr in dataTable.Rows)
                {
                    dtClone.ImportRow(dr);
                }
                /*
                 * codigo em https://stackoverflow.com/questions/22970418/copy-c-sharp-datatable-and-convert-all-values-to-string
                 */
                sfComboBox1.DataSource = dtClone;
                sfComboBox1.DisplayMember = "ID";
                sfComboBox1.Text = Idequipa;


                /*
                 * 
                 */

                querry = "SELECT ID FROM tab_tasks";
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(dset, "idtas");
                DataTable dataTable1 = dset.Tables["idtas"];
                /*
                * codigo em https://stackoverflow.com/questions/22970418/copy-c-sharp-datatable-and-convert-all-values-to-string
                */
                DataTable dtClone1 = dataTable1.Clone(); //just copy structure, no data
                for (int a = 0; a < dtClone.Columns.Count; a++)
                {
                    if (dtClone1.Columns[a].DataType != typeof(string))
                        dtClone1.Columns[a].DataType = typeof(string);
                }

                foreach (DataRow dr in dataTable1.Rows)
                {
                    dtClone1.ImportRow(dr);
                }
                /*
                 * codigo em https://stackoverflow.com/questions/22970418/copy-c-sharp-datatable-and-convert-all-values-to-string
                 */
                
                sfComboBox2.DataSource = dtClone1;
                sfComboBox2.DisplayMember = "idtas";
                sfComboBox2.Text = Idtask;
            }
            maskedTextBox1.Enabled = false;
            maskedTextBox1.ReadOnly = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (sfComboBox1.SelectedItem == null || sfComboBox2.SelectedItem == null)
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                if (sfComboBox1.SelectedItem == null)
                {
                    toolStripButton1.ToolTipText = "Verifique o preenchimento de todos os campos antes de validar dados";
                }
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                {
                    querry = "INSERT INTO tab_agend (ID, IDEquipa, IDTask)" +
                          "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox2.Text;
                }
                else
                {
                    querry = "UPDATE tab_agend  SET IDEquipa = @IDEquipa, IDTask = @IDTask where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox2.Text;
                }
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
