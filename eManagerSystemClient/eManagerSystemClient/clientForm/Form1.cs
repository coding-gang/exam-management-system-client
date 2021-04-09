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
                    int receiveBylength = client.Receive(data);
                  string nameLink =   SaveFile(data,receiveBylength);
                    SetText(nameLink);
                  
                }

            }
            catch(Exception er)
            {
                throw er;
               // Close();
            }
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {



            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblDeThi.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblDeThi.Text = text;
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

       
        private string SaveFile(byte[] data, int dataLength)
        {
            string pathSave = "D:/";
            int fileNameLength = BitConverter.ToInt32(data, 0);
            string nameFile = Encoding.ASCII.GetString(data,4, fileNameLength);
            string name = pathSave +Path.GetFileName(nameFile);
           
            BinaryWriter writer = new BinaryWriter(File.Open(name, FileMode.Append));
            int count = dataLength - 4 - fileNameLength;
            writer.Write(data, 4 + fileNameLength,count);
            return name;
        }

        private void cmdKetNoi_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblDeThi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblDeThi.LinkVisited = true; 
            System.Diagnostics.Process.Start(this.lblDeThi.Text);
        }
        public void SenFile(string filePath)
        {
            try
            {
                if (filePath != String.Empty)
                {
                 //  client.Send(GetFilePath(filePath));
                    
                }
            }
            catch
            {
                MessageBox.Show("file không tồn tại");
                return;

            }
          
            
        }
        public byte[] GetFilePath(string filePath)
        {
            //  var name = Path.GetFileName(filePath);
            byte[] fNameByte = Encoding.ASCII.GetBytes(filePath);
            byte[] fileData = File.ReadAllBytes(filePath);
            byte[] serverData = new byte[4 + fNameByte.Length + fileData.Length];
            byte[] fNameLength = BitConverter.GetBytes(fNameByte.Length);
            fNameLength.CopyTo(serverData, 0);
            fNameByte.CopyTo(serverData, 4);
            fileData.CopyTo(serverData, 4 + fNameByte.Length);
            return serverData;
        }

        private void cmdNopBaiThi_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\1812860.docx";
            SenFile(filePath);


        }
    }


}
