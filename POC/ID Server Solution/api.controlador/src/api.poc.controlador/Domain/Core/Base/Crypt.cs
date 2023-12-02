using System.Security.Cryptography;
using System.Text;

namespace Domain.Core.Base
{
    public class Crypt
    {
        private string _secretKey;
        private string _salt;
        private string _hashAlgorithm;                // SHA1 ou MD5
        private int _passwordIterations;                   // qq valor
        private string _initVector;       // must be 16 bytes
        public string _chave;
        private int _keySize;

        public Crypt()
        {
            _secretKey = "backspr0d";
            _salt = "3|y5r0";
            _hashAlgorithm = "SHA1";                // SHA1 ou MD5
            _passwordIterations = 5;                   // qq valor
            _initVector = "04|R0#&M#D0T#N&T";       // must be 16 bytes
            _keySize = 256;
        }



        public string EncryptDESFunction(string cyphertext, string key = null)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            DES.Mode = CipherMode.ECB;
            //DES.Key = GetKey(password);
            DES.Key = Encoding.UTF8.GetBytes(key ?? _secretKey);
            DES.Padding = PaddingMode.PKCS7;

            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = Encoding.ASCII.GetBytes(cyphertext);

            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public string DecryptDESFunction(string cyphertext, string key = null)
        {

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            DES.Mode = CipherMode.ECB;
            DES.Key = Encoding.UTF8.GetBytes(key ?? _secretKey);
            DES.Padding = PaddingMode.PKCS7;

            ICryptoTransform DESEncrypt = DES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(cyphertext);

            return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));


        }

        public string EncryptAESFunction(string sDados)
        {
            // Converte strings em byte arrays e aceita somente caracteres ASCII
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(_salt);

            // Converte dados em byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(sDados);

            // Criar um password para criar a chave derivada
            PasswordDeriveBytes password = new PasswordDeriveBytes(_secretKey, saltValueBytes, _hashAlgorithm, _passwordIterations);

            // Usar o password para gerar o pseudo-random bytes para encripitar
            byte[] keyBytes = password.GetBytes(_keySize / 8);

            // Criar o objeto de encriptação Rijndael
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            // Gerar encryptor com base na chave criada
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            // Encriptando.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Converter dado encripitado para string base64-encoded.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }

        public string DecryptAESFunction(string sDadosEncriptados)
        {
            // Converte strings em byte arrays e aceita somente caracteres ASCII
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(_salt);

            // Converte dados encripitados em byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(sDadosEncriptados);

            PasswordDeriveBytes password = new PasswordDeriveBytes(_secretKey, saltValueBytes, _hashAlgorithm, _passwordIterations);
            byte[] keyBytes = password.GetBytes(_keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            return plainText;
        }

    }
}
