using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using System.Linq;
using System.Windows.Input;

namespace SimuSecApp
{
    public class Client
    {
        int port = 11120;
        string host= "192.168.14.24";
        public byte[] key = new byte[16];
        public byte[] iv = new byte[16];
        NetworkStream stream;
        TcpClient tcpClient;

        public void ExecuteClient()
        {
            try {
                tcpClient = new TcpClient(host, port);
                KeyExchange();

            }

            catch {
                System.Windows.MessageBox.Show("Server offline... ");
                System.Windows.Forms.Application.Exit();
                
            }
            
        }
        public void KeyExchange()
        {
            // Receive the key and IV from server
            this.key = new byte[16];
            tcpClient.GetStream().Read(this.key, 0, 16);
            this.iv = new byte[16];
            tcpClient.GetStream().Read(this.iv, 0, 16);

        }
        public string PackByProtocol(string[] args, string type = "")
        {
            string fullString = "";

            if(type != "")
                fullString = type + ":::";

            foreach (var item in args)
            {
                fullString += item + ":::";
            }

            fullString = fullString.Remove(fullString.Length - 3, 3);

            return fullString;

        }
        public string[] SplitByProtocol(string packedMsg)
        {
            string[] args = packedMsg.Split(':');

            string fullString = "";

            foreach(var item in args)
            {
                if(item != "")
                    fullString += item + "~";
            }
            fullString = fullString.Remove(fullString.Length - 1, 1);

            string[] toReturn = fullString.Split('~');

            return toReturn;

        }
        public int RecvLength()
        {
            // Create a buffer to hold the integer bytes (4 bytes)
            byte[] intBytes = new byte[4];
            stream = tcpClient.GetStream();

            // Receive the integer bytes
            int bytesRead = 0;
            while (bytesRead < 4)
            {
                int count = stream.Read(intBytes, bytesRead, 4 - bytesRead);
                if (count == 0)
                {
                    throw new EndOfStreamException("Stream closed while receiving integer.");
                }
                bytesRead += count;
            }

            // Convert the integer bytes to an integer in network byte order
            int number = BitConverter.ToInt32(intBytes, 0);
            number = IPAddress.NetworkToHostOrder(number);

            return number;
        }

        public string[] Receive()
        {
            // Receive the length of the ciphertext as a 4-byte big-endian integer
            byte[] lengthBytes = new byte[4];
            tcpClient.GetStream().Read(lengthBytes, 0, 4);
            int length = BitConverter.ToInt32(lengthBytes.Reverse().ToArray(), 0);


            // Receive the ciphertext itself
            byte[] ciphertext = new byte[length];
            //tcpClient.GetStream().Read(ciphertext, 0, length);

            // Receive the integer bytes
            int bytesRead = 0;
            while (bytesRead < length)
            {
                int count = tcpClient.GetStream().Read(ciphertext, bytesRead, length - bytesRead);
                if (count == 0)
                {
                    throw new EndOfStreamException("Stream closed while receiving integer.");
                }
                bytesRead += count;
            }

            // Decrypt the ciphertext
            string plaintext = DecryptStringFromBytes(ciphertext);

            System.Windows.Forms.MessageBox.Show(plaintext);
            string[] result = SplitByProtocol(plaintext);

            return result;
        }
        public string DecryptStringFromBytes(byte[] cipherText)
        {
            // Create an AES object with the specified key and IV
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                // Create a decryptor to perform the stream transform
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    // Create a MemoryStream to hold the decrypted data
                    using (MemoryStream msDecrypt = new MemoryStream())
                    {
                        // Create a CryptoStream to perform the decryption
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                        {
                            // Write the encrypted data to the CryptoStream
                            csDecrypt.Write(cipherText, 0, cipherText.Length);

                            // Flush the CryptoStream to ensure all the data has been written
                            csDecrypt.FlushFinalBlock();

                            // Convert the decrypted data from a byte array to a string
                            return Encoding.UTF8.GetString(msDecrypt.ToArray());
                        }
                    }
                }
            }
        }


        public byte[] ReceiveBytes()
        {
            // Read the length of the message from the network stream
            byte[] lengthBytes = new byte[4];
            
            tcpClient.GetStream().Read(lengthBytes, 0, 4);
            int length = BitConverter.ToInt32(lengthBytes, 0);

            // Create a buffer to hold the message data
            byte[] buffer = new byte[length];

            // Read the message data from the network stream
            int totalBytesRead = 0;
            while (totalBytesRead < length)
            {
                int bytesRead = tcpClient.GetStream().Read(buffer, totalBytesRead, length - totalBytesRead);
                totalBytesRead += bytesRead;
            }

            return buffer;
        }

        public byte[] Pad(string message)
        {
            int paddingLength = 16 - (message.Length % 16);
            byte paddingByte = (byte)paddingLength;
            byte[] padding = Enumerable.Repeat(paddingByte, paddingLength).ToArray();
            return Encoding.UTF8.GetBytes(message).Concat(padding).ToArray();
        }



        public void Send(string message)
        {
            byte[] paddedMessage = Pad(message);
            byte[] encryptedMessage;
            byte[] messageLengthBytes = new byte[4];

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                encryptedMessage = encryptor.TransformFinalBlock(paddedMessage, 0, paddedMessage.Length);
            }

            NetworkStream stream = tcpClient.GetStream();

            byte[] lengthBytes = BitConverter.GetBytes(encryptedMessage.Length);
            Array.Copy(lengthBytes, messageLengthBytes, lengthBytes.Length);

            stream.Write(messageLengthBytes, 0, 4);
            stream.Write(encryptedMessage, 0, encryptedMessage.Length);
        }














        public byte[] EncryptStringToBytes(string plainText)
        {
            byte[] Key = this.key;
            byte[] IV = this.key;

            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7; // use PKCS7 padding

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
            
        }



        public static byte[] Decrypt(byte[] encrypted, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                // Create a decryptor to perform the stream transform
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Create the streams used for decryption
                using (MemoryStream msDecrypt = new MemoryStream(encrypted))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        // Read the decrypted bytes from the CryptoStream
                        using (MemoryStream ms = new MemoryStream())
                        {
                            csDecrypt.CopyTo(ms);
                            byte[] decrypted = ms.ToArray();

                            return decrypted;
                        }
                    }
                }
            }
        }










        // using UTF8 encoding for the messages
        static Encoding encoding = Encoding.UTF8;

        public void ReleaseSocket()
        {
            tcpClient.Close();
        }
    }
}
