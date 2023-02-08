using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;

namespace SimuSecApp
{
    public class Client
    {
        byte[] bytes = new byte[1024];
        int port = 11112;
        string host= "127.0.0.1";
        int byteCount;
        byte[] sendData;
        NetworkStream stream;
        TcpClient tcpClient;

        public void ExecuteClient()
        {
            try {
                tcpClient = new TcpClient(host, port);
            }

            catch {
                MessageBox.Show("Server offline... ");
                Application.Exit();
                
            }
            
        }

        public string Receive()
        {
            // Read the data from the stream
            byte[] data = new byte[1024];
            int bytesRead = stream.Read(data, 0, data.Length);

            // Convert the data to a string
            string receivedData = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);

            MessageBox.Show("Received: " + receivedData);

            return receivedData;
        }

        private string PackLength(string message)
        {
            int length = message.Length;
            string str_len = length.ToString("D4");

            return str_len;
        }

        private void SendLength(string message)
        {
            sendData = new byte[4];
            sendData = Encoding.ASCII.GetBytes(PackLength(message));
            stream = tcpClient.GetStream();
            stream.Write(sendData, 0, sendData.Length);
        }
        public void Send(string message)
        {
            try
            {
                SendLength(message);
                byteCount = Encoding.ASCII.GetByteCount(message);
                sendData = new byte[byteCount];
                sendData = Encoding.ASCII.GetBytes(message);
                stream = tcpClient.GetStream();
                stream.Write(sendData, 0, sendData.Length);
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Failed to send data");
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
