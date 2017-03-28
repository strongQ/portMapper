using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace portmap_net
{
    internal class program
    {
        #region Fields (4)

        private static StringBuilder _console_buf = new StringBuilder();
        private static int _id_plus = 0;
       
        
        public const string product_version = "1.0.0.2";
        public const string product_version_addl = "beta";
        
       
        #endregion Fields

        #region Methods (8)

        // Private Methods (8) 

        //private static List<work_group> load_maps_cfg()
        //{
        //    string maps_cfg = ConfigurationManager.AppSettings["portmaps"];
        //    if (string.IsNullOrEmpty(maps_cfg))
        //        throw new Exception("配置文件错误: 缺少PortMap配置");

        //    string[] tmp1 = maps_cfg.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (tmp1.Length == 0)
        //        throw new Exception("配置文件错误: 缺少PortMap配置");

        //    List<work_group> rtn = new List<work_group>();
        //    foreach (string tmp2 in tmp1)
        //    {
        //        string[] tmp3 = tmp2.Split(new[] { '|' });
        //        if (tmp3.Length != 2)
        //            throw new Exception("配置文件错误: 每组PortMap配置必须为2个节点");
        //        work_group rtn_item = new work_group { _id = ++_id_plus };
        //        for (int i = 0; i != 2; ++i)
        //        {
        //            string[] tmp4 = tmp3[i].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        //            if (tmp4.Length != 2)
        //                throw new Exception("配置文件错误: IP节点格式错误");
        //            IPAddress ip = IPAddress.Any;
        //            if (i == 0 && tmp4[0] != "*" && !IPAddress.TryParse(tmp4[0], out ip))
        //                throw new Exception("配置文件错误: IP节点格式错误");
        //            ushort port;
        //            if (!ushort.TryParse(tmp4[1], out port))
        //                throw new Exception("配置文件错误: IP节点格式错误");
        //            if (i == 0)
        //                rtn_item._point_in = new IPEndPoint(ip, port);
        //            if (i == 1)
        //            {
        //                rtn_item._point_out_host = tmp4[0];
        //                rtn_item._point_out_port = port;
        //            }
        //        }
        //        rtn.Add(rtn_item);
        //    }
        //    return rtn;
        //}
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 初始化数据库
            DBSQLite.SQLite db = new DBSQLite.SQLite();
            Database.InitDB(db);           
            Application.Run(new FrmMapper());
        }
        //private static void Main(string[] args)
        //{
        //    Console.Title = "PM_TestV1.0";

        //    List<work_group> maps_list;
        //    try
        //    {
        //        maps_list = load_maps_cfg();
        //    }
        //    catch (Exception exp)
        //    {
        //        Console.WriteLine(program_ver);
        //        Console.WriteLine(exp.Message);
        //        system("pause");
        //        return;
        //    }
        //    foreach (var map_item in maps_list)
        //    {
        //        map_start(map_item);
        //    }

        //    Console.CursorVisible = false;
        //    while (true)
        //    {
        //        show_stat();
        //        Thread.Sleep(2000);
        //    }
        //}

       

        #endregion Methods

        private const string program_ver = @"[PM_Test(1.0)]
--------------------------------------------------";
    }
}
