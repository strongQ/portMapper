using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace portmap_net
{
    public static class ExtendMethod
    {
       
        public static string ToIP(this EndPoint ep)
        {
            return ep.ToString().Split(':')[0];
        }
        public static string ToPort(this EndPoint ep)
        {
            return ep.ToString().Split(':')[1];
        }
     
    }
}
