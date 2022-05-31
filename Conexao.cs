using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Conexao : Form
    {
        public Conexao()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (!File.Exists("FILENAME.txt")) // If file does not exists
            {
                File.Create("FILENAME.txt").Close(); // Create file
                using (StreamWriter sw = File.AppendText("FILENAME.txt"))
                {

                }
            }
            else // If file already exists
            {
                File.WriteAllText("FILENAME.txt", String.Empty); // Clear file
                using (StreamWriter sw = File.AppendText("FILENAME.txt"))
                {
                    sw.WriteLine(textBox1.Text); // Write text to .txt file
                }

            }
            OleDbConnection con = new OleDbConnection(textBox1.Text);
            if (textBox1.Text != "" && textBox1.Text != null)
            {
                try
                {
                    con.Open();
                    Tables.Caminho = textBox1.Text;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na conexão, verifique o caminho do ficheiro\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Cancelado", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
