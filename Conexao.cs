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

        string key = "b14ca5898a4e4133bbce2ea2315a1916";
        string text;

        private void Button1_Click(object sender, EventArgs e)
        {
            // verifica se o campo esta vazio
            if (textBox1.Text == "")
            {
                sfToolTip1.Show("Introduza a chave de conexão antes de continuar");
                return;
            }

            try
            {
                // verifica se o valor do campo é uma chave válida
                OleDbConnection con = new OleDbConnection(textBox1.Text);
                con.Open();
                Tables.Caminho = textBox1.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão, verifique a chave de conexão.\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!File.Exists("ChaveConexao.txt")) // If file does not exists
            {
                File.Create("ChaveConexao.txt").Close(); // Create file
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    text = textBox1.Text;


                    var encryptedString = AesOperation.EncryptString(key, text);
                    // encript text


                    sw.WriteLine(encryptedString); // Write text to .txt file
                    MessageBox.Show("Conexao alterada", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // If file already exists
            {
                File.WriteAllText("ChaveConexao.txt", String.Empty); // Clear file
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    text = textBox1.Text;

                    // Encript Text
                    var encryptedString = AesOperation.EncryptString(key, text);

                    sw.WriteLine(encryptedString); // Write text to .txt file
                }

            }
            this.Close();
        }


        private void Button1_MouseLeave_1(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }

        private void Conexao_Load(object sender, EventArgs e)
        {
            // Ao carregar o FORM, verifica se já existe um ficheiro e caso exista, vai buscar o texto atual do mesmo
            if (!File.Exists("ChaveConexao.txt")) // If file does not exists
            {
                File.Create("ChaveConexao.txt").Close(); // Create file
                MessageBox.Show("Não foi configurada nenhuma conexão, configure a conexão.");
            }
            else // If file already exists
            {
                text = File.ReadAllText("ChaveConexao.txt");

                //Desencript Text
                var decryptedString = AesOperation.DecryptString(key, text);

                textBox1.Text = decryptedString;

                button1.Select();

            }
        }
    }
}
