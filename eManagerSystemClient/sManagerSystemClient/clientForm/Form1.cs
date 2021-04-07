using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace clientForm
{
    public partial class Form1 : Form
    { 
     
        public Form1()
        {
            InitializeComponent();
        
        }

        IPEndPoint IP;
        Socket client;
        public void Connect()
        {

            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Khong the ket noi toi server");
                return;

            }
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();


        }
        public void Send(string message)
        {
            if (message != String.Empty)
            {
                client.Send(Serialize(message));
            }

        }

        public void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                   
                }

            }
            catch(Exception er)
            {
            
                Close();
            }


        }
    
        public void Close()
        {
            client.Close();
        }

        private byte[] Serialize(object data)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(memoryStream, data);
            return memoryStream.ToArray();
        }

        private object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
          return  formatter.Deserialize(stream);
          
        }

        private void cmdKetNoi_Click(object sender, EventArgs e)
        {
            Connect();
        }
    }
}
