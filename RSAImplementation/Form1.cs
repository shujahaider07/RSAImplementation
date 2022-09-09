using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSAImplementation
{
    public partial class Form1 : Form
    {
        ASCIIEncoding byteConverter = new ASCIIEncoding();
        RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedText;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        static public byte[] Encryption(byte[] Data, RSAParameters RSAkey, bool DoOAEPPadding)
        {


            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAkey); encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;


            } 


                

            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }


        static public byte[] Decryption(byte[] Data, RSAParameters RSAkey, bool DoOAEPPadding)
        {

            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAkey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);

                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            plaintext = byteConverter.GetBytes(encTxt.Text);
            encryptedText = Encryption(plaintext,rSA.ExportParameters(false),false);
            decTxtx.Text = byteConverter.GetString(encryptedText);




        }

        private void button2_Click(object sender, EventArgs e)
                {
                    byte[] decText = Decryption(encryptedText,rSA.ExportParameters(true),false);
                    textBox3.Text = byteConverter.GetString(decText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
     
        }
    }

    }




