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
        string Provid;
        string DSource;
        string Password;

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

            if (!File.Exists("ChaveConexao.txt"))
            {
                File.Create("ChaveConexao.txt").Close();
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    Provid = textBox1.Text;
                    DSource = textBox2.Text;
                    Password = textBox3.Text;
                    var encryptedString = AesOperation.EncryptString(key, Provid);
                    sw.WriteLine("Provid = " + Provid + ";");
                    encryptedString = AesOperation.EncryptString(key, DSource);
                    sw.WriteLine("Data Source = " + DSource + ";");

                    encryptedString = AesOperation.EncryptString(key, Password);
                    sw.WriteLine("Jet OLEDB:Database Password = " + Password);
                }
            }
            else
            {
                File.WriteAllText("ChaveConexao.txt", String.Empty);
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    Provid = textBox1.Text;
                    DSource = textBox2.Text;
                    Password = textBox3.Text;
                    var encryptedString = AesOperation.EncryptString(key, Provid);
                    sw.WriteLine("Provid = " + Provid + ";");
                    encryptedString = AesOperation.EncryptString(key, DSource);
                    sw.WriteLine("Data Source = " + DSource + ";");

                    encryptedString = AesOperation.EncryptString(key, Password);
                    sw.WriteLine("Jet OLEDB:Database Password = " + Password);
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
            }
            else // If file already exists
            {
                /*text = File.ReadAllText("ChaveConexao.txt");
                //Desencript Text
                text1 = text.Substring(0, 64);
                text2 = text.Substring(65, 64);
                text3 = text.Substring(63 + 64, 26);
                var decryptedString1 = AesOperation.DecryptString(key, text1);
                var decryptedString2 = AesOperation.DecryptString(key, text2);
                var decryptedString3 = AesOperation.DecryptString(key, text3);

                textBox1.Text = decryptedString1 + decryptedString2 + decryptedString3;

                button1.Select();*/

            }
        }
    }
}
