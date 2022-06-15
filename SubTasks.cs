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
        DataSet dset = new DataSet();
        OleDbDataAdapter adapter;
        string querry;
        public string Tipo { get; set; }
        public int ID { get; set; }
        public int IDTask { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        private void Subtasks_Load(object sender, EventArgs e)
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
            if (Tipo == "Add")
            {
                string comand = "SELECT MAX (ID) FROM tab_subtasks";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
                
            }
            else
            {
                maskedTextBox1.Text = ID.ToString();
            }
  
            maskedTextBox2.Text = Desc;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            maskedTextBox3.Enabled = true;
            maskedTextBox3.Text = IDTask.ToString();
            button1.Select();
            querry = "SELECT DISTINCT Type FROM tab_subtasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            sfComboBox2.DataSource = dataTable;
            sfComboBox2.DisplayMember = "ID";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "" || sfComboBox2.Text == "")
            {
                sfToolTip1.Show("Verifique todos os campos antes de modificar dados.");
                return;
            }
            if (Tipo == "Add")
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
                querry = "UPDATE tab_subtasks SET [IDTask] = @IDTask, [Desc] = @Desc, [Type] = @Type " +
                    "WHERE [ID] =" + maskedTextBox1.Text;
                oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = maskedTextBox3.Text;
                oleDbCommand.Parameters.Add("@Desc", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@Type", OleDbType.LongVarChar).Value = sfComboBox2.Text;
            }
            
            try
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
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Select();
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Select();
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }

        private void Subtasks_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
