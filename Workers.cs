using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string IdEquipa { get; set; }
        public string Img { get; set; }
        public string Cod { get; set; }
        string query;
        private void Workers_Load(object sender, EventArgs e)
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
            // Add data.
            if (Tipo == "Add")
            {
                // Get new Id.
                query = "SELECT MAX (ID) FROM tab_workers";
                OleDbCommand oleDbCommand = new OleDbCommand(query, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            // Modify data.
            {
                maskedTextBox1.Text = ID.ToString();
            }
            DataSet dset = new DataSet();
            OleDbDataAdapter adapter;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.Text = Name;
            maskedTextBox4.Text = Img;
            maskedTextBox5.Text = Cod;
            maskedTextBox1.Enabled = false;
            button1.Select();
            // Gets Data for ComboBox
            query = "SELECT ID AS Id, Descricao AS Descrição FROM tab_teams";
            adapter = new OleDbDataAdapter(query, connection);
            adapter.Fill(dset, "idteam");
            DataTable dataTable = dset.Tables["idteam"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";
            sfComboBox1.Text = IdEquipa;
            connection.Close();
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
            // Check if all fields are written.
            if ((maskedTextBox2.Text == null) || (maskedTextBox4.Text == null) || (sfComboBox1.SelectedItem == null)
                || (maskedTextBox5.Text == null))
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                // Check data type.
                bool a = int.TryParse(maskedTextBox5.Text, out int maskedbox5);
                if (a != true)
                {
                    // Return if not int / a number.
                    sfToolTip1.Show("Foram detetados dados incorretos\n verifique os dados introduzidos");
                    return;
                }
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                // Add data.
                {
                    query = "INSERT INTO tab_workers (ID, Nome, IDEquipa, img, Cod) VALUES (@ID, @Nome, @IDEquipa, @img, @Cod)";
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                    oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                }
                else
                // Modify data.
                {
                    query = "UPDATE tab_workers  SET Nome = @Nome, IDEquipa = @IDEequipa, img = @img, Cod = @Cod where ID = "
                        + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(query, connection);
                    oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                    oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                }
                try
                {
                    // Execute command.
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel atualizar dados\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados atualizados com sucesso", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            connection.Close();
            this.Close();
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
