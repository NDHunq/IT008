using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace aes
{
    public class AES1
    {
        //[DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")] public static extern bool ZeroMemory(IntPtr Destination, int Length);
        //public static byte[] GenerateRandomSalt()
        //{
        //    byte[] data = new byte[32];
        //    using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        //    {
        //        for (int i = 0; i < 10; i++) { rng.GetBytes(data); }
        //    }
        //    return data;
        //}
        //public void FileEncrypt(string inputFile, string password)
        //{
        //    byte[] salt = GenerateRandomSalt();
        //    FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);
        //    byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
        //    RijndaelManaged AES = new RijndaelManaged();
        //    AES.KeySize = 256; AES.BlockSize = 128;
        //    AES.Padding = PaddingMode.PKCS7;
        //    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
        //    AES.Key = key.GetBytes(AES.KeySize / 8);
        //    AES.IV = key.GetBytes(AES.BlockSize / 8);
        //    AES.Mode = CipherMode.CFB;
        //    fsCrypt.Write(salt, 0, salt.Length);
        //    CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
        //    FileStream fsIn = new FileStream(inputFile, FileMode.Open);
        //    byte[] buffer = new byte[1048576];
        //    int read;
        //    try
        //    {
        //        while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            Application.DoEvents(); cs.Write(buffer, 0, read);
        //        }
        //        fsIn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        cs.Close(); fsCrypt.Close();
        //    }
        //}
        //public void FileDecrypt(string inputFile, string outputFile, string password)
        //{
        //    byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
        //    byte[] salt = new byte[32];
        //    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
        //    fsCrypt.Read(salt, 0, salt.Length);
        //    RijndaelManaged AES = new RijndaelManaged();
        //    AES.KeySize = 256; AES.BlockSize = 128;
        //    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
        //    AES.Key = key.GetBytes(AES.KeySize / 8);
        //    AES.IV = key.GetBytes(AES.BlockSize / 8);
        //    AES.Padding = PaddingMode.PKCS7;
        //    AES.Mode = CipherMode.CFB;
        //    CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
        //    FileStream fsOut = new FileStream(outputFile, FileMode.Create);
        //    int read;
        //    byte[] buffer = new byte[1048576];
        //    try
        //    {
        //        while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            Application.DoEvents(); fsOut.Write(buffer, 0, read);
        //        }
        //    }
        //    catch (CryptographicException ex_CryptographicException)
        //    {
        //        Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    try
        //    {
        //        cs.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
        //    }
        //    finally
        //    {
        //        fsOut.Close();
        //        fsCrypt.Close();
        //    }
        //}
        
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}