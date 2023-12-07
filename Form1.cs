using System.Security.Cryptography;
using System.Text;

namespace Kriptograma_WPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateWarning();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            UpdateWarning();
            textBoxResults.Text = "";
            string password = string.Empty;
            string stringKey = textBoxKey.Text;
            if (radioButtonEncrypt.Checked)
            {
                password = textBoxPassword.Text;
                if (Method_AES.Checked)
                {
                    EncryptAES(password, stringKey);
                }
                if (Method_3DES.Checked)
                {
                    Encrypt3DES(password, stringKey);
                }
            }
            if (radioButtonDecrypt.Checked)
            {
                if (Method_AES.Checked && Method_AES.Enabled)
                {
                    password = File.ReadAllText("AES.txt");
                    DecryptAES(password, stringKey);
                }
                if (Method_3DES.Checked && Method_3DES.Enabled)
                {
                    password = File.ReadAllText("3DES.txt");
                    Decrypt3DES(password, stringKey);
                }
            }
            UpdateWarning();
        }

        public void UpdateWarning()
        {
            bool fileAES = false;
            bool file3DES = false;
            string warning;
            if (File.Exists("AES.txt")) { fileAES = true; }
            if (File.Exists("3DES.txt")) { file3DES = true; }
            if (fileAES == true && file3DES == true)
            {
                Method_3DES.Enabled = true;
                Method_AES.Enabled = true;
                radioButtonEncrypt.Enabled = true;
                radioButtonDecrypt.Enabled = true;
                textBoxWarnings.ForeColor = Color.Black;
                textBoxWarnings.Text = "Yra failai: 'AES.txt' ir '3DES.txt'.";
            }
            else if (fileAES == true && file3DES == false)
            {
                if (radioButtonDecrypt.Checked)
                {
                    Method_3DES.Enabled = false;
                    Method_AES.Enabled = true;
                }
                else
                {
                    Method_3DES.Enabled = true;
                    Method_AES.Enabled = true;
                }
                textBoxWarnings.ForeColor = Color.Black;
                textBoxWarnings.Text = "Yra 'AES.txt' failas.";
            }
            else if (fileAES == false && file3DES == true)
            {
                if (radioButtonDecrypt.Checked)
                {
                    Method_3DES.Enabled = true;
                    Method_AES.Enabled = false;
                }
                else
                {
                    Method_3DES.Enabled = true;
                    Method_AES.Enabled = true;
                }
                textBoxWarnings.ForeColor = Color.Black;
                textBoxWarnings.Text = "Yra '3DES.txt' failas.";
            }
            else
            {
                if (radioButtonDecrypt.Checked)
                {
                    Method_3DES.Enabled = false;
                    Method_AES.Enabled = false;
                }
                else
                {
                    Method_3DES.Enabled = true;
                    Method_AES.Enabled = true;
                }
                textBoxWarnings.ForeColor = Color.Red;
                textBoxWarnings.Text = "Nera nei vieno failo.";
            }
            if (radioButtonDecrypt.Checked) { textBoxPassword.Enabled = false; }
            else { textBoxPassword.Enabled = true; }
        }

        public static byte[] MakeKey(string text, int size)
        {
            byte[] fakeKey = new byte[size];
            byte[] textBytes = Encoding.UTF8.GetBytes(text);

            for (int i = 0; i < size; i++)
            {
                if (textBytes.Length > i)
                {
                    fakeKey[i] = (byte)textBytes[i];
                }
                else
                {
                    fakeKey[i] = (byte)i;
                }
            }
            return fakeKey;
        }

        public static byte[] MakeIv(byte[] key, int size)
        {
            byte[] fakeKey = new byte[size];
            for (int i = 0; i < size / 2; i++)
            {
                fakeKey[i] = key[i * 2];
                fakeKey[i + size / 2] = key[i * 2 + 1];
            }
            return fakeKey;
        }

        public void EncryptAES(string password, string stringKey)
        {
            byte[] key = MakeKey(stringKey, 32);
            byte[] iv = MakeIv(key, 16);
            string text = string.Empty;
            bool success = false;

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (FileStream fileStream = new FileStream("AES.txt", FileMode.OpenOrCreate))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            try
                            {
                                streamWriter.Write(password);
                                success = true;
                            }
                            catch
                            {
                                textBoxResults.Text += "Nepavyko užšifruoti slaptažodžio AES budu" + "\r\n";
                            }
                        }
                    }
                }
                if (success)
                {
                    text = File.ReadAllText("AES.txt");
                    textBoxResults.Text += "Slaptazodis uzsifruotas AES: " + text + "\r\n";
                }
            }
        }
        public void Encrypt3DES(string password, string stringKey)
        {
            byte[] key = MakeKey(stringKey, 24);
            byte[] iv = MakeIv(key, 8);
            string text = string.Empty;
            bool success = false;

            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.KeySize = 192;
                tripleDES.Key = key;
                tripleDES.IV = iv;

                using (FileStream fileStream = new FileStream("3DES.txt", FileMode.OpenOrCreate))
                {
                    ICryptoTransform encryptor = tripleDES.CreateEncryptor(tripleDES.Key, tripleDES.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            try
                            {
                                streamWriter.Write(password);
                                success = true;
                            }
                            catch
                            {
                                textBoxResults.Text += "Nepavyko užšifruoti slaptažodžio 3DES budu" + "\r\n";
                            }
                        }
                    }
                }
                if (success)
                {
                    text = File.ReadAllText("3DES.txt");
                    textBoxResults.Text += "Slaptazodis uzsifruotas 3DES: " + text + "\r\n";
                }
            }
        }

        public void DecryptAES(string password, string stringKey)
        {
            byte[] key = MakeKey(stringKey, 32);
            byte[] iv = MakeIv(key, 16);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                using (FileStream fileStream = new FileStream("AES.txt", FileMode.Open))
                {
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            try
                            {
                                string decryptedPassword = streamReader.ReadToEnd();
                                textBoxResults.Text += "Slaptažodis atšifruotas (AES): " + decryptedPassword + "\r\n";
                            }
                            catch
                            {
                                textBoxResults.Text += "Nepavyko atšifruoti slaptažodžio (AES)" + "\r\n";
                            }
                        }
                    }
                }
            }
        }

        public void Decrypt3DES(string password, string stringKey)
        {
            byte[] key = MakeKey(stringKey, 24);
            byte[] iv = MakeIv(key, 8);

            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider())
            {
                tripleDES.KeySize = 192;
                tripleDES.Key = key;
                tripleDES.IV = iv;

                using (FileStream fileStream = new FileStream("3DES.txt", FileMode.Open))
                {
                    ICryptoTransform decryptor = tripleDES.CreateDecryptor(tripleDES.Key, tripleDES.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            try
                            {
                                string decryptedPassword = streamReader.ReadToEnd();
                                textBoxResults.Text += "Slaptažodis atšifruotas (3DES): " + decryptedPassword + "\r\n";
                            }
                            catch
                            {
                                textBoxResults.Text += "Nepavyko atšifruoti slaptažodžio (3DES)" + "\r\n";
                            }
                        }
                    }
                }
            }
        }

        private void radioButtonEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWarning();
        }

        private void radioButtonDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWarning();
        }
    }
}