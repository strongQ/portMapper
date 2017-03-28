using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace portmap_net
{
    public class Database
    {
        public static DBSQLite.SQLite db { set; get; }
        public static DBSQLite.SQLite Sqlite { get { return db; } }

        public static void InitDB(DBSQLite.SQLite pDB)
        {
            db = pDB;
            
            DBSQLite.DBCreater dbCreater = new DBSQLite.DBCreater();
            DBSQLite.DBCreater.tbTable tb = null;
            tb = new DBSQLite.DBCreater.tbTable("work_group", db); tb.AddField("T1ID", "int", true);
            tb.AddField("T1INIP", "varchar(50)", false);
            tb.AddField("T1INPORT", "int", false);
            tb.AddField("T1OUTIP", "varchar(50)", false);
            tb.AddField("T1OUTPORT", "int", false);
            tb.AddField("T1NAME", "varchar(50)", false);
            tb.AddField("T1MAXNUM", "int", false);
            tb.AddField("T1STARTTIME", "varchar(50)", false);
            tb.AddField("T1STOPTIME", "varchar(50)", false);
            tb.AddField("T1SINGLEMAX", "int", false); dbCreater.AddTable(tb);



            dbCreater.TryUpdate();
        }


        #region 自动生成与 2016-07-28 05:40:16 ByDBClassCreater
        /// <summary>映射组
        /// 映射组 
        /// </summary>
        public partial class work_group
        {
            private int _T1ID = 0;
            /// <summary>
            /// 编号 
            /// </summary> 
            public int T1ID
            {
                get { return _T1ID; }
                set { _T1ID = value; }
            }
            private string _T1INIP = string.Empty;
            /// <summary>
            /// 输入IP 
            /// </summary> 
            public string T1INIP
            {
                get { return _T1INIP; }
                set { _T1INIP = value; }
            }
            private int _T1INPORT = 0;
            /// <summary>
            /// 输入端口 
            /// </summary> 
            public int T1INPORT
            {
                get { return _T1INPORT; }
                set { _T1INPORT = value; }
            }
            private string _T1OUTIP = string.Empty;
            /// <summary>
            /// 输出IP 
            /// </summary> 
            public string T1OUTIP
            {
                get { return _T1OUTIP; }
                set { _T1OUTIP = value; }
            }
            private int _T1OUTPORT = 0;
            /// <summary>
            /// 输出端口 
            /// </summary> 
            public int T1OUTPORT
            {
                get { return _T1OUTPORT; }
                set { _T1OUTPORT = value; }
            }
            private string _T1NAME = string.Empty;
            /// <summary>
            /// 名称 
            /// </summary> 
            public string T1NAME
            {
                get { return _T1NAME; }
                set { _T1NAME = value; }
            }
            private int _T1MAXNUM = 0;
            /// <summary>
            /// 最大连接数 
            /// </summary> 
            public int T1MAXNUM
            {
                get { return _T1MAXNUM; }
                set { _T1MAXNUM = value; }
            }
            private string _T1STARTTIME = string.Empty;
            /// <summary>
            /// 启动开始时间 
            /// </summary> 
            public string T1STARTTIME
            {
                get { return _T1STARTTIME; }
                set { _T1STARTTIME = value; }
            }
            private string _T1STOPTIME = string.Empty;
            /// <summary>
            /// 启动结束时间 
            /// </summary> 
            public string T1STOPTIME
            {
                get { return _T1STOPTIME; }
                set { _T1STOPTIME = value; }
            }
            private int _T1SINGLEMAX = 0;
            /// <summary>
            /// 单IP最大连接数 
            /// </summary> 
            public int T1SINGLEMAX
            {
                get { return _T1SINGLEMAX; }
                set { _T1SINGLEMAX = value; }
            }

            public static work_group Load(int pT1ID)
            {
                string tsql = string.Format("select  T1ID,T1INIP,T1INPORT,T1OUTIP,T1OUTPORT,T1NAME,T1MAXNUM,T1STARTTIME,T1STOPTIME,T1SINGLEMAX from work_group where T1ID ={0}", pT1ID);
                var dt = db.GetDataTable(tsql);
                if (dt.Rows.Count == 0) return null;
                DataRow dr = dt.Rows[0];
                work_group obj = Load(dr);
                return obj;
            }
            public static work_group Load(DataRow dr)
            {
                work_group obj = new work_group();
                obj.T1ID = dr["T1ID"] != DBNull.Value ? Convert.ToInt32(dr["T1ID"]) : 0;
                obj.T1INIP = dr["T1INIP"] != DBNull.Value ? Convert.ToString(dr["T1INIP"]) : string.Empty;
                obj.T1INPORT = dr["T1INPORT"] != DBNull.Value ? Convert.ToInt32(dr["T1INPORT"]) : 0;
                obj.T1OUTIP = dr["T1OUTIP"] != DBNull.Value ? Convert.ToString(dr["T1OUTIP"]) : string.Empty;
                obj.T1OUTPORT = dr["T1OUTPORT"] != DBNull.Value ? Convert.ToInt32(dr["T1OUTPORT"]) : 0;
                obj.T1NAME = dr["T1NAME"] != DBNull.Value ? Convert.ToString(dr["T1NAME"]) : string.Empty;
                obj.T1MAXNUM = dr["T1MAXNUM"] != DBNull.Value ? Convert.ToInt32(dr["T1MAXNUM"]) : 0;
                obj.T1STARTTIME = dr["T1STARTTIME"] != DBNull.Value ? Convert.ToString(dr["T1STARTTIME"]) : string.Empty;
                obj.T1STOPTIME = dr["T1STOPTIME"] != DBNull.Value ? Convert.ToString(dr["T1STOPTIME"]) : string.Empty;
                obj.T1SINGLEMAX = dr["T1SINGLEMAX"] != DBNull.Value ? Convert.ToInt32(dr["T1SINGLEMAX"]) : 0;
                return obj;
            }
            public static void Save(work_group obj)
            {
                string tsql = string.Empty;
                if (obj.T1ID == 0)
                {
                    //新增 
                    int maxid = db.GetMaxID("work_group", "T1ID") + 1;
                    obj.T1ID = maxid;
                    tsql = string.Format("insert into work_group(T1ID,T1INIP,T1INPORT,T1OUTIP,T1OUTPORT,T1NAME,T1MAXNUM,T1STARTTIME,T1STOPTIME,T1SINGLEMAX) values({0},'{1}',{2},'{3}',{4},'{5}',{6},'{7}','{8}',{9})", obj.T1ID, obj.T1INIP.Replace("'", "''"), obj.T1INPORT, obj.T1OUTIP.Replace("'", "''"), obj.T1OUTPORT, obj.T1NAME.Replace("'", "''"), obj.T1MAXNUM, obj.T1STARTTIME.Replace("'", "''"), obj.T1STOPTIME.Replace("'", "''"), obj.T1SINGLEMAX);
                }
                else
                {
                    tsql = string.Format("update work_group set T1ID ={0} , T1INIP ='{1}' , T1INPORT ={2} , T1OUTIP ='{3}' , T1OUTPORT ={4} , T1NAME ='{5}' , T1MAXNUM ={6} , T1STARTTIME ='{7}' , T1STOPTIME ='{8}' , T1SINGLEMAX ={9} where T1ID ={0}", obj.T1ID, obj.T1INIP.Replace("'", "''"), obj.T1INPORT, obj.T1OUTIP.Replace("'", "''"), obj.T1OUTPORT, obj.T1NAME.Replace("'", "''"), obj.T1MAXNUM, obj.T1STARTTIME.Replace("'", "''"), obj.T1STOPTIME.Replace("'", "''"), obj.T1SINGLEMAX, obj.T1ID);
                }
                //执行
                db.Execute(tsql);
            }
            public static void Save(work_group[] objs)
            {
                string tsql = string.Empty;
                DBSQLite.SQLite.TransactionExecute te = new DBSQLite.SQLite.TransactionExecute(Sqlite);
                int maxid = db.GetMaxID("work_group", "T1ID") + 1;
                for (int i = 0; i < objs.Length; i++)
                {
                    work_group obj = objs[i];
                    if (obj.T1ID == 0)
                    {
                        //新增 
                        obj.T1ID = maxid + i;
                        tsql = string.Format("insert into work_group(T1ID,T1INIP,T1INPORT,T1OUTIP,T1OUTPORT,T1NAME,T1MAXNUM,T1STARTTIME,T1STOPTIME,T1SINGLEMAX) values({0},'{1}',{2},'{3}',{4},'{5}',{6},'{7}','{8}',{9})", obj.T1ID, obj.T1INIP.Replace("'", "''"), obj.T1INPORT, obj.T1OUTIP.Replace("'", "''"), obj.T1OUTPORT, obj.T1NAME.Replace("'", "''"), obj.T1MAXNUM, obj.T1STARTTIME.Replace("'", "''"), obj.T1STOPTIME.Replace("'", "''"), obj.T1SINGLEMAX);
                    }
                    else
                    {
                        tsql = string.Format("update work_group set T1ID ={0} , T1INIP ='{1}' , T1INPORT ={2} , T1OUTIP ='{3}' , T1OUTPORT ={4} , T1NAME ='{5}' , T1MAXNUM ={6} , T1STARTTIME ='{7}' , T1STOPTIME ='{8}' , T1SINGLEMAX ={9} where T1ID ={0}", obj.T1ID, obj.T1INIP.Replace("'", "''"), obj.T1INPORT, obj.T1OUTIP.Replace("'", "''"), obj.T1OUTPORT, obj.T1NAME.Replace("'", "''"), obj.T1MAXNUM, obj.T1STARTTIME.Replace("'", "''"), obj.T1STOPTIME.Replace("'", "''"), obj.T1SINGLEMAX, obj.T1ID);
                    }
                    //执行
                    te.Execute(tsql);
                }
                //提交
                te.TransactionSubmit();
            }
            /// <summary>
            /// 基本对象集合查询
            /// </summary>
            /// <param name="tsql">查询的TSQL表达式</param>
            /// <returns>对象集合</returns>
            public static work_group[] SelectObjectBase(string tsql)
            {
                List<work_group> result = new List<work_group>();
                DataTable dt = db.GetDataTable(tsql);
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(work_group.Load(dr));
                }
                return result.ToArray();
            }

            /// <summary>
            /// 基本表单查询
            /// </summary>
            /// <param name="tsql">查询的TSQL表达式</param>
            /// <returns>表单</returns>
            public static DataTable SelectDataTableBase(string tsql)
            {
                DataTable dt = db.GetDataTable(tsql);
                return dt;
            }
            public static void Delete(work_group obj)
            {
                string tsql = string.Format("delete from work_group where T1ID ={0}", obj.T1ID);
                //执行
                db.Execute(tsql);
            }
        }
        #endregion




        public partial class work_group
        {
            public static void Delete(int id)
            {
                string tsql = string.Format("delete from work_group where T1ID ={0}", id);
                //执行
                db.Execute(tsql);
            }
            public static int SaveReturn(work_group obj)
            {
                string tsql = string.Empty;
                if (obj.T1ID == 0)
                {
                    //新增 
                    int maxid = db.GetMaxID("work_group", "T1ID") + 1;
                    obj.T1ID = maxid;
                    tsql = string.Format("insert into work_group(T1ID,T1INIP,T1INPORT,T1OUTIP,T1OUTPORT,T1NAME,T1MAXNUM,T1STARTTIME,T1STOPTIME,T1SINGLEMAX) values({0},'{1}',{2},'{3}',{4},'{5}',{6},'{7}','{8}',{9})", obj.T1ID, obj.T1INIP.Replace("'", "''"), obj.T1INPORT, obj.T1OUTIP.Replace("'", "''"), obj.T1OUTPORT, obj.T1NAME.Replace("'", "''"), obj.T1MAXNUM, obj.T1STARTTIME.Replace("'", "''"), obj.T1STOPTIME.Replace("'", "''"), obj.T1SINGLEMAX);
                }
                else
                {
                    tsql = string.Format("update work_group set T1ID ={0} , T1INIP ='{1}' , T1INPORT ={2} , T1OUTIP ='{3}' , T1OUTPORT ={4} , T1NAME ='{5}' , T1MAXNUM ={6} , T1STARTTIME ='{7}' , T1STOPTIME ='{8}' , T1SINGLEMAX ={9} where T1ID ={0}", obj.T1ID, obj.T1INIP.Replace("'", "''"), obj.T1INPORT, obj.T1OUTIP.Replace("'", "''"), obj.T1OUTPORT, obj.T1NAME.Replace("'", "''"), obj.T1MAXNUM, obj.T1STARTTIME.Replace("'", "''"), obj.T1STOPTIME.Replace("'", "''"), obj.T1SINGLEMAX, obj.T1ID);
                }
                //执行
                db.Execute(tsql);
                return obj.T1ID;
            }
        }
    }
}
