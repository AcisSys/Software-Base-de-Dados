using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Subtasks : Form
    {
        public Subtasks()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        OleDbCommand oleDbCommand;
        string querry;
        public string Tipo { get; set; }
        public int Id { get; set; }
        public int IdTask { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        private void Subtasks_Load(object sender, EventArgs e)
        {
            // Check Connection
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
            // Add new Data
            if (Tipo == "Add")
            {
                string comand = "SELECT MAX (ID) FROM tab_subtasks";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            // Change existent Data
            else
            {
                maskedTextBox1.Text = Id.ToString();
            }
            OleDbDataAdapter adapter;
            DataSet dset = new DataSet();
            maskedTextBox2.Text = Desc;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            maskedTextBox3.Enabled = true;
            maskedTextBox3.Text = IdTask.ToString();
            button1.Select();
            DataTable dataTable;
            querry = "SELECT DISTINCT Type FROM tab_subtasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "type");
            dataTable = dset.Tables["type"];
            /*
             * codigo em https://stackoverflow.com/questions/22970418/copy-c-sharp-datatable-and-convert-all-values-to-string
             */
            DataTable dtClone = dataTable.Clone(); //just copy structure, no data
            for (int i = 0; i < dtClone.Columns.Count; i++)
            {
                if (dtClone.Columns[i].DataType != typeof(string))
                {
                    dtClone.Columns[i].DataType = typeof(string);
                }
            }
            foreach (DataRow dr in dataTable.Rows)
            {
                dtClone.ImportRow(dr); // Imports all rows from DataTable to the clone (with String type on every column)
            }
            /*
             * codigo em https://stackoverflow.com/questions/22970418/copy-c-sharp-datatable-and-convert-all-values-to-string
             */
            sfComboBox2.DataSource = dtClone;
            sfComboBox2.DisplayMember = "Type";
            sfComboBox2.Text = Type;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // check all fields
            if ((maskedTextBox2.Text == "") || (maskedTextBox3.Text == ""))
            {
                sfToolTip1.Show("Verifique todos os campos antes de modificar dados.");
                return;
            }
            else
            {
                // Checks data type
                bool a = int.TryParse(maskedTextBox3.Text, out int maskedbox2);
                if (a != true)
                {
                    sfToolTip1.Show("Foram detetados dados incorretos\n verifique os dados introduzidos");
                    return;
                }
            }
            if (Tipo == "Add")
            // add data
            {
                querry = "INSERT INTO tab_subtasks ([ID], [IDTask], [Desc], [Type])" +
                   "VALUES (@ID, @IDTask, @Desc, @Type)";
                oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = maskedTextBox3.Text;
                oleDbCommand.Parameters.Add("@Desc", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@Type", OleDbType.LongVarChar).Value = sfComboBox2.Text;
            }
            else
            {
                // modify data
                querry = "UPDATE tab_subtasks SET [IDTask] = @IDTask, [Desc] = @Desc, [Type] = @Type " +
                    "WHERE [ID] =" + maskedTextBox1.Text;
                oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = maskedTextBox3.Text;
                oleDbCommand.Parameters.Add("@Desc", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@Type", OleDbType.LongVarChar).Value = sfComboBox2.Text;
            }
            try
            //execute command
            {
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Dados adicionados com sucesso", "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
