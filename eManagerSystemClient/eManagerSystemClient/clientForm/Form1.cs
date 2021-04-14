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
using eManagerSystem.Application;
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
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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

        public object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
         
            return formatter.Deserialize(stream);
          
        }

        public void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                     client.Receive(data);

                    SendData receiveData = new SendData();
                    receiveData = (SendData)Deserialize(data);
                    switch ((string)Deserialize(receiveData.option))
                    {
                        case "Send File":
                            int receiveBylength = receiveData.data.Length;

                            string nameLink = SaveFile(receiveData.data, receiveBylength);
                            SetText(nameLink);
                            break;
                        case "Send User":
                            var userList = (List<Students>)Deserialize(receiveData.data);
                            SetData(userList);
                            break;
                        default:
                            break;
                    }
                 
                }

            }
            catch(Exception er)
            {
             
                Close();
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

        delegate void SetDataSourceCallBack(List<Students> students);

        private void SetData(List<Students> students)
        {
          
            if (this.cbDSThi.InvokeRequired)
            {
                SetDataSourceCallBack d = new SetDataSourceCallBack(SetData);
                this.Invoke(d, new object[] { students });
            }
            else
            {
                this.cbDSThi.DataSource = students;        
                this.cbDSThi.DisplayMember = "FullName";
                this.cbDSThi.ValueMember = "MSSV";
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

       

        private void lblDeThi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.lblDeThi.LinkVisited = true;
            System.Diagnostics.Process.Start(this.lblDeThi.Text);
        }

        private void cmdChapNhan_Click(object sender, EventArgs e)
        {

        }

        private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbDSThi.SelectedItem != null)
            {
             
                string MSSV = cbDSThi.SelectedValue.ToString();
                if(MSSV != "eManagerSystem.Application.Students")
                {
                    MessageBox.Show(MSSV);
                    lblMaSo.Text = MSSV;
                    lblHoTen.Text = cbDSThi.Text;
                }
            

        

            }
        }
    }




    

}
