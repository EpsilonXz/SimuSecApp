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
        int port = 11111;
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

        public void Receive(TcpClient client)
        {
            int i = 0;
            while (stream.DataAvailable)
            {
                bytes[i] = ((byte)stream.ReadByte());
                i++;
            }

            string data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            MessageBox.Show("Received: " + data);
        }

        private void Send(string message)
        {
            try
            {
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
