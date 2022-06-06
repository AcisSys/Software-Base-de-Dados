﻿using System;
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
        static string key = "bbce2ea2315a1916";
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

            if (!File.Exists("ChaveConexao.txt"))
            {
                File.Create("ChaveConexao.txt").Close();
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    Provid = textBox1.Text;
                    DSource = textBox2.Text;
                    Password = textBox3.Text;

                    // encrypt

                    var encryptedString = AesOperation.EncryptString(key, Provid);
                    sw.WriteLine("Provider = " + Provid + ";");
                    //encryptedString = AesOperation.EncryptString(key, DSource);
                    sw.WriteLine("Data Source = " + DSource + ";");
                    //encryptedString = AesOperation.EncryptString(key, Password);
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

                    // encrypt

                    var encryptedString = AesOperation.EncryptString(key, Provid);
                    sw.WriteLine("Provider = " + Provid + ";");
                    //encryptedString = AesOperation.EncryptString(key, DSource);
                    sw.WriteLine("Data Source = " + DSource + ";");
                    //encryptedString = AesOperation.EncryptString(key, Password);
                    sw.WriteLine("Jet OLEDB:Database Password = " + Password);
                }
            }
            // verifica se o valor do campo é uma chave válida
            try
            {
                Tables.Caminho = File.ReadAllText("ChaveConexao.txt");
                OleDbConnection con = new OleDbConnection(Tables.Caminho);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão, verifique a chave de conexão.\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void Button1_MouseLeave_1(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }

        private void Conexao_Load(object sender, EventArgs e)
        {
            // Verifica se o ficheiro existe
            if (File.Exists("ChaveConexao.txt"))
            {
                using (var reader = new StreamReader("ChaveConexao.txt"))
                {
                    Provid = reader.ReadLine();
                    DSource = reader.ReadLine();
                    Password = reader.ReadLine();
                }
                // Verifica se contem texto
                if (Provid != "")
                {
                    // Mostra o texto ao user
                    textBox1.Text = Provid.Substring(11, Provid.Length - 12);
                    textBox2.Text = DSource.Substring(14, DSource.Length - 15);
                    textBox3.Text = Password.Substring(30, Password.Length - 30);
                }
            }
        }
    }
}
