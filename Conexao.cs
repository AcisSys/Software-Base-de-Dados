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
        string text1;
        string text2;
        string text3;

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


                    //var encryptedString = AesOperation.EncryptString(key, text);
                    // encript text


                    //sw.WriteLine(encryptedString); // Write text to .txt file
                    MessageBox.Show("Conexao alterada", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // If file already exists
            {
                File.WriteAllText("ChaveConexao.txt", String.Empty); // Clear file
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    text = textBox1.Text;
                    text1 = textBox1.Text.ToString().Substring(0, 62);
                    int a = textBox1.TextLength;
                    text2 = textBox1.Text.ToString().Substring(62, 45);

                    // Encript Text
                    var encryptedString = AesOperation.EncryptString(key, text1);
                    var encryptedString2 = AesOperation.EncryptString(key, text2);

                    sw.WriteLine(encryptedString + encryptedString2); // Write text to .txt file
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
                text1 = text.Substring(0, 64);
                text2 = text.Substring(65, 64);
                text3 = text.Substring(63 + 64, 26);
                var decryptedString1 = AesOperation.DecryptString(key, text1);
                var decryptedString2 = AesOperation.DecryptString(key, text2);
                var decryptedString3 = AesOperation.DecryptString(key, text3);

                textBox1.Text = decryptedString1 + decryptedString2 + decryptedString3;

                button1.Select();

            }
        }
    }
}
