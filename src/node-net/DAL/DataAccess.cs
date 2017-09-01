using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public abstract class DataAccess
    {
        public string ConnectionString
        {
            get
            {
                return
                    //"Server=.\\SQLExpress;AttachDbFilename=D:\\dev-self\\node\\node-net\\DAL\\DB\\NodeByWCF.mdf;Database=NodeByWCF; Trusted_Connection=Yes;";
                @"Data Source=.\SQLEXPRESS;
                          AttachDbFilename=D:\dev-self\node\node-net\DAL\DB\NodeByWCF.mdf;
                          Integrated Security=True;
                          Connect Timeout=30;
                          User Instance=True";
                //return "Data Source =DESKTOP-EVM02NE\\MAHSA; Initial Catalog = NodeByWCF; Integrated Security=true ";
                //return ConfigurationSettings.AppSettings["ConnectionString"].ToString();  
            }
        }

        protected Int32 ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

    }
}