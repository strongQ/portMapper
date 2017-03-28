using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace portmap_net
{
   public class TransClient
    {
        public TcpClient BeginClient { get; set; }
        public TcpClient RemoteClient { get; set; }
    }
}
