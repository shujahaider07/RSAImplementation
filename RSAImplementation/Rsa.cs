using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSAImplementation
{
   

    internal class Rsa
    {
        UnicodeEncoding byteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedText;

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



    }
}
