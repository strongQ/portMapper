using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Linq;
using System.Windows.Forms;
using Zhangqi;

namespace portmap_net
{
    public class PortMap
    {

        #region 属性字段
        private bool _isAuto=true;
        private int id;
        private string name;
        private string point_in_host;
        private int point_in_port;
        private string point_out_host;
        private int point_out_port;
        private string start_time;
        private string stop_time;
        private int singleNum;
        private int maxNum;
        private bool isRun = false;
        private int _sendBytes;
        private int _recieveBytes;

        public int RecieveBytes
        {
            get { return _recieveBytes; }
            set { _recieveBytes = value; }
        }
      

        public bool IsAuto 
        {
            get { return _isAuto; }
            set { _isAuto = value; }
        }

        public int SendBytes
        {
            get { return _sendBytes; }
            set { _sendBytes = value; }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
      

        public int Point_in_port
        {
            get { return point_in_port; }
            set { point_in_port = value; }
        }

        public string Point_in_host
        {
            get
            {
                return point_in_host;
            }

            set
            {
                point_in_host = value;
            }
        }

        public string Point_out_host
        {
            get
            {
                return point_out_host;
            }

            set
            {
                point_out_host = value;
            }
        }

        public int Point_out_port
        {
            get
            {
                return point_out_port;
            }

            set
            {
                point_out_port = value;
            }
        }

        public string Start_time
        {
            get
            {
                return start_time;
            }

            set
            {
                start_time = value;
            }
        }

        public string Stop_time
        {
            get
            {
                return stop_time;
            }

            set
            {
                stop_time = value;
            }
        }

        public int SingleNum
        {
            get
            {
                return singleNum;
            }

            set
            {
                singleNum = value;
            }
        }

        public int MaxNum
        {
            get
            {
                return maxNum;
            }

            set
            {
                maxNum = value;
            }
        }

        public bool IsRun
        {
            get
            {
                return isRun;
            }

            set
            {
                isRun = value;
            }
        }
        #endregion
        //public static Dictionary<int, stat_obj> _stat_info = new Dictionary<int, stat_obj>();
        //public static Dictionary<int, List<List<Socket>>> sockets = new Dictionary<int, List<List<Socket>>>();
        //public static Dictionary<int, Dictionary<string, List<string>>> singleIP = new Dictionary<int, Dictionary<string, List<string>>>();
        //public static Dictionary<string, List<object>> threads = new Dictionary<string, List<object>>();
        public const int bufSize = 4096;
        byte[] send_buf = new byte[bufSize];
        byte[] recieve_buf = new byte[bufSize];
        public List<TcpClient> tcpClientList = new List<TcpClient>();
        public TcpListener serverListener { get; set; }
        public Dictionary<string,List<TcpClient>> SingleDic
        {
            get
            {
               // socketList.RemoveAll(y => y.Poll(10, SelectMode.SelectRead));
                if (tcpClientList.Count>0)
                return tcpClientList.ToLookup(x=>
                {
                    try
                    {
                        return x.Client.RemoteEndPoint.ToIP();
                        }
                    catch 
                    {
                        tcpClientList.Remove(x);
                        return string.Empty;
                    }
                    }
                ).ToDictionary(g=>g.Key,g=>g.ToList());
                else
                {
                    return null;
                }
            }
        }
        // 启动端口映射
        public string StartMap()
        {
           
            LogHelpMe.WriteLog(string.Format("{0} 映射启动了哦", this.Name), LogHelpMe.LogEnum.提示);


            // 创建一个socket监听
            //Socket beginSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           
            
            try
            {
                if (this.Point_in_host == "Any IP")
                {
                    serverListener = new TcpListener(new IPEndPoint(IPAddress.Any, this.point_in_port));
                }
                else
                {
                    serverListener = new TcpListener(new IPEndPoint(IPAddress.Parse(this.Point_in_host), this.point_in_port));
                }
                serverListener.Start(100);
                serverListener.BeginAcceptTcpClient(on_local_connected, serverListener);                
            }
            catch (Exception exp)
            {
                LogHelpMe.WriteLog(exp.Message, LogHelpMe.LogEnum.错误);
                return "wrong";
            }

            return "";
        }

        private void on_local_connected(IAsyncResult ar)
        {
            TcpClient beginClient;
            try
            {
                 beginClient = serverListener.EndAcceptTcpClient(ar);
            }
            catch(Exception ee)
            {
                Zhangqi.LogHelpMe.WriteLog(ee.Message+ee.StackTrace, LogHelpMe.LogEnum.错误);
                return;
            }

             serverListener.BeginAcceptTcpClient (on_local_connected, serverListener);
            FrmMapper.IsClear = false;
            if (tcpClientList.Count > 0)
            {
                if (tcpClientList.Count >= this.MaxNum)
                {
                    string message = (string.Format("客户端'{0}'无法连接，{1} 总连接数目超限", beginClient.Client.RemoteEndPoint.ToString(), this.Name));
                    LogHelpMe.WriteLog(message, LogHelpMe.LogEnum.警告);
                    FrmMapper.IsClear = true;
                    return;
                }
                if (SingleDic.ContainsKey(beginClient.Client.RemoteEndPoint.ToIP()))
                if (SingleDic != null && SingleDic[beginClient.Client.RemoteEndPoint.ToIP()].Count >= this.SingleNum)
                {
                    string message = (string.Format("客户端'{0}'无法连接，{1} 单连接数目超限", beginClient.Client.RemoteEndPoint.ToString(), this.Name));
                    LogHelpMe.WriteLog(message, LogHelpMe.LogEnum.警告);
                     FrmMapper.IsClear = true;
                     return;
                }
            }
           
            tcpClientList.Add(beginClient);
            if (SingleDic == null) return;
            LogHelpMe.WriteLog(string.Format("客户端'{0}'连接进来,{1} 该IP单连接数目为 {2}", beginClient.Client.RemoteEndPoint.ToString(),
                Name, SingleDic[beginClient.Client.RemoteEndPoint.ToIP()].Count), LogHelpMe.LogEnum.提示);

            // 连接到转发的Socket
            TcpClient remoteClient = new TcpClient();
          
            try
            {
                TransClient transClient= new TransClient() { RemoteClient = remoteClient, BeginClient = beginClient };
                remoteClient.Connect(IPAddress.Parse(this.Point_out_host), this.Point_out_port);
                beginClient.Client.BeginReceive(send_buf, 0, 4096, SocketFlags.None, new AsyncCallback(AsyncSend), transClient);
                remoteClient.Client.BeginReceive(recieve_buf, 0, 4096, SocketFlags.None, new AsyncCallback(AsyncRecieve),transClient);
              
                FrmMapper.IsClear = true;
                
            }
            catch
            {
                LogHelpMe.WriteLog(string.Format("{0} 转发端口失败,监听服务器没有开启", Name), LogHelpMe.LogEnum.错误);
                tcpClientList.Remove(beginClient);
            }
        }

        private void AsyncRecieve(IAsyncResult ar)
        {
            TransClient transClient = (TransClient)ar.AsyncState;
            try
            {
                int bytesRead = transClient.RemoteClient.Client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    transClient.BeginClient.Client.Send(recieve_buf, bytesRead, SocketFlags.None);
                   // transSocket.ClientSocket.BeginSend(recieve_buf, 0, bytesRead, SocketFlags.None, new AsyncCallback(asyncRecieveData), transSocket.ClientSocket);
                    this.RecieveBytes += bytesRead;
                }
                transClient.RemoteClient.Client.BeginReceive(recieve_buf, 0, 4096, SocketFlags.None, new AsyncCallback(AsyncRecieve), transClient);
            }
            catch (Exception ee)
            {
                Zhangqi.LogHelpMe.WriteLog(ee.Message+ee.StackTrace, LogHelpMe.LogEnum.错误);             
            }
        }

        private void asyncRecieveData(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.     
            Socket handler = (Socket)ar.AsyncState;
            // Complete sending the data to the remote device.     
            int bytesSent = handler.EndSend(ar);
        }

        private void AsyncSend(IAsyncResult ar)
        {

            TransClient transClient = (TransClient)ar.AsyncState;
            try
            {
                int bytesRead = transClient.BeginClient.Client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    transClient.RemoteClient.Client.Send(send_buf, bytesRead, SocketFlags.None);
                    // transSocket.RemoteSocket.BeginSend(send_buf, 0, bytesRead, SocketFlags.None, new AsyncCallback(asyncSendData), transSocket.RemoteSocket);
                    this.SendBytes += bytesRead;
                }
                transClient.BeginClient.Client.BeginReceive(send_buf, 0, 4096, SocketFlags.None, new AsyncCallback(AsyncSend), transClient);
            }
            catch (Exception ee)
            {
                Zhangqi.LogHelpMe.WriteLog(ee.Message+ee.StackTrace, LogHelpMe.LogEnum.错误);       
            }
        }

        private void asyncSendData(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.     
            Socket handler = (Socket)ar.AsyncState;
            // Complete sending the data to the remote device.     
            int bytesSent = handler.EndSend(ar);
        }
    






        [DllImport("msvcrt.dll")]
        private static extern bool system(string str);
    }
}
