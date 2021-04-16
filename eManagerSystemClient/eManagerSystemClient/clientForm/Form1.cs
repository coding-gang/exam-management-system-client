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
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace clientForm
{
    public partial class Form1 : Form
    {
        IPEndPoint IP;
        Socket client;
        string _pathName;
        int counter = 0;
        System.Timers.Timer countdown; 
        public Form1()
        {
            InitializeComponent();
            countdown = new System.Timers.Timer();
            countdown.Interval = 1000;
            countdown.Elapsed += Countdown_Elapsed;
            cmdChapNhan.Enabled = false;
            cmdNopBaiThi.Enabled = false;
            cbDSThi.Enabled = false;
          
        }
        void checkNopBaiThi()
        {
            if(lblThoiGianConLai.Text != string.Empty && lblDeThi.Text != string.Empty)
            {
                cmdNopBaiThi.Enabled = false;
            }
        }

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            counter -= 1;
            int minute = counter / 60;
            int second = counter % 60;
            SetCounter(minute, second);
            if (counter == 0)
            {
                countdown.Stop();
                FinishExam();
                Close();
            }


        }
        delegate void SetCounterCallback(int minute, int second);
        private void SetCounter(int minute, int second)
        {
            if (this.lblDeThi.InvokeRequired)
            {
                SetCounterCallback d = new SetCounterCallback(SetCounter);
                this.Invoke(d, new object[] { minute, second });
            }

            else
            {
                this.lblThoiGianConLai.Text = minute + " : " + second; ;
            }
        }


        delegate void SetTimeCallback(object time, int mintute);


        private void SetTime(object time, int minute)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblThoiGian.InvokeRequired)
            {
                SetTimeCallback d = new SetTimeCallback(SetTime);
                this.Invoke(d, new object[] { time, minute });
            }

            else
            {

                this.lblThoiGian.Text = time.ToString() + " Phút";
                counter = minute * 60;

                countdown.Enabled = true;
            }
        }
        private void FinishExam()
        {
            try
            {

                var PathName = @_pathName;
                string nameDic = Directory.GetDirectories(PathName).FirstOrDefault();
                SendToServer(nameDic);
                lblThoiGianConLai.Text = "0 " + "phút";
                cmdNopBaiThi.Enabled = false;
             
            }
            catch
            {
                MessageBox.Show("lưu bài theo hướng dẫn!");
            }
        }
        public void SendToServer(string filePath)
        {
            try
            {
                if (filePath != String.Empty)
                {
                    SendData serverReponse = new SendData();
                    
                    serverReponse.option = Serialize("Send Exam");
                    serverReponse.data = Serialize(GetFilePath(filePath));
                    client.Send(Serialize(serverReponse));
                    MessageBox.Show("Nộp bài thành công");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public byte[] GetFilePath(string filePath)
        {
           
            byte[] fNameByte = Encoding.ASCII.GetBytes(filePath);
            string nameFile = Directory.EnumerateFiles(filePath).FirstOrDefault();
            byte[] fileData = File.ReadAllBytes(nameFile);
            byte[] serverData = new byte[4 + fNameByte.Length + fileData.Length];
            byte[] fNameLength = BitConverter.GetBytes(fNameByte.Length);
            fNameLength.CopyTo(serverData, 0);
            fNameByte.CopyTo(serverData, 4);
            fileData.CopyTo(serverData, 4 + fNameByte.Length);
            return serverData;
        }
        public void Connect()
        {
            string hostName = Dns.GetHostName();
            string currentIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            IP = new IPEndPoint(IPAddress.Parse(currentIP), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(IP);

                MessageBox.Show("Connect server success!");
                cmdKetNoi.Enabled = false;
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
        public void SendAcceptUser(string mssv)
        {
            if (mssv != String.Empty)
            {
                SendData sendData = new SendData
                {
                    option = Serialize("Send Accept"),
                    data = Serialize(mssv)
                };
                
                client.Send(Serialize(sendData));
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
                            this.Invoke(new Action(() => { cmdNopBaiThi.Enabled = true; }));
                            break;
                        case "Send User":
                            var userList = (List<Students>)Deserialize(receiveData.data);
                            SetData(userList);
                            break;
                        case "Send UserFromExcel":
                            var userListFile = (List<StudentFromExcel>)Deserialize(receiveData.data);
                            SetData(userListFile);
                            break;
                        case "Send Subject":
                            var subject = (string)Deserialize(receiveData.data);
                            SetSubject(subject);
                            break;
                        case "Send BeginExam":
                            object timeExam = (object)Deserialize(receiveData.data);
                            int minute = int.Parse(timeExam.ToString());
                            SetTime(timeExam, minute);             
                            break;
                        case "Send Decline":
                            string message = (string)Deserialize(receiveData.data);
                            this.Invoke(new Action(() => { MessageBox.Show(this, message); }));
                            break;
                        case "Send Success":
                            string messageSuccess = (string)Deserialize(receiveData.data);
                            this.Invoke(new Action(() => { MessageBox.Show(this, messageSuccess); }));
                            break;
                        case "Send ActiveControl":
                            string active = (string)Deserialize(receiveData.data);
                            this.Invoke(new Action(() => {
                                cmdChapNhan.Enabled = true;
                                checkNopBaiThi();
                                cbDSThi.Enabled = true;
                               // cmdKetNoi.Enabled = true;

                            }));
                         
                            break;
                        case "Send ClientPath":
                            string pathClient = (string)Deserialize(receiveData.data);
                            SetClientPath(pathClient);
                            break;
                        case "Send LogOut":
                            this.Invoke(new Action(() => { LogOutuser(); })) ;
                            break;
                        case "Send ShutDown":
                            this.Invoke(new Action(() => { ShutDown(); }));
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

        void SetClientPath(string pathName)
        {
            _pathName = pathName;
        }

        delegate void SetTextCallback(string text);

        private void SetSubject(string text)
        {
          
            if (this.lblMonThi.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSubject);
                lblMonThi.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblMonThi.Text = text;
            }
        }
        private void SetText(string text)
        {
        
            if (this.lblDeThi.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                lblDeThi.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblDeThi.Text = text;
            }
        }

       

        delegate void SetDataSourceCallBack(IEnumerable<object> students);

        private void SetData(IEnumerable<object> students)
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
            string pathSave = _pathName;
            if (!Directory.Exists(pathSave))
            {
                Directory.CreateDirectory(pathSave);
            }
            int fileNameLength = BitConverter.ToInt32(data, 0);
            string nameFile = Encoding.ASCII.GetString(data,4, fileNameLength);
            string name = pathSave+@"\" +Path.GetFileName(nameFile);
           
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
            if(lblMaSo.Text != string.Empty)
            {
               
                SendAcceptUser(lblMaSo.Text);
                cmdChapNhan.Enabled = false;

            }
            else
            {
                MessageBox.Show("Ban chua chon Ten thi sinh");
            }
           
        }

        private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbDSThi.SelectedItem != null)
            {
             
                string MSSV = cbDSThi.SelectedValue.ToString();
                if(MSSV != "eManagerSystem.Application.Students")
                {
                    lblMaSo.Text = MSSV;
                    lblHoTen.Text = cbDSThi.Text;
                }
           
            }
        }
        private void cmdNopBaiThi_Click(object sender, EventArgs e)
        {                
                countdown.Stop();
                FinishExam();
             
        }

     public void LogOutuser()
        {
            Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
        }

        public void ShutDown()
        {
            Process.Start("shutdown", "/s /t 0");
        }
     
    }




    

}
