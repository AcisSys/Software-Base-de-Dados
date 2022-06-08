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
        static readonly string caminho = Tables.Caminho;
        public readonly OleDbConnection connection = new OleDbConnection(caminho);
        DataSet dset = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        public string Tipo { get; set; }
        public int ID { get; set; }
        public int IDTask { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        private void Subtasks_Load(object sender, EventArgs e)
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
            button1.Text = "Modificar";
            maskedTextBox1.Text = ID.ToString();
            maskedTextBox2.Text = Desc;
            sfComboBox2.Text = Type;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            maskedTextBox3.Enabled = false;
            string querry;
            DataTable dataTable;
            querry = "SELECT DISTINCT Type FROM tab_subtasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "type");
            dataTable = dset.Tables["type"];
            maskedTextBox3.Text = IDTask.ToString();
            button1.Select();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "" || sfComboBox2.Text == "")
            {
                sfToolTip1.Show("Verifique todos os campos antes de modificar dados.");
                return;
            }
            string querry = "UPDATE tab_subtasks VALUES IDTask = @IDTask, Desc = @Desc, Type = @Type" +
                     "WHERE ID =" + maskedTextBox1.Text;
            OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
            oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = maskedTextBox3.Text;
            oleDbCommand.Parameters.Add("@Desc", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
            oleDbCommand.Parameters.Add("@Type", OleDbType.LongVarChar).Value = sfComboBox2.Text;
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
    }
}
