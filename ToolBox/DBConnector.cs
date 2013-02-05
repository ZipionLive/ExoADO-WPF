using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ToolBox
{
    public class DBConnector
    {
        public string login { get; private set; }
        private string pwd;

        public DBConnector (Dictionary<string, string> connectParams)
        {
            foreach (KeyValuePair<string, string> kvp in connectParams)
            {
                if (kvp.Key.Equals("login"))
                    this.login = kvp.Value;
                else if (kvp.Key.Equals("password"))
                    this.pwd = kvp.Value;
            }
        }

        public SqlConnection CreateDBConnect()
        {
            //SqlParameter sqlpLogin = new SqlParameter();
            //sqlpLogin.ParameterName = "@login";
            //sqlpLogin.Value = this.login;

            //SqlParameter sqlpPassword = new SqlParameter();
            //sqlpPassword.ParameterName = "@password";
            //sqlpPassword.Value = pwd;

            StringBuilder csBuild = new StringBuilder();
            csBuild.Append(@"Data Source=ASPIRE-5560G\ZLSQL; Initial Catalog=AdventureWorks2008R2; User Id=");
            csBuild.Append(this.login);
            csBuild.Append("; Password=");
            csBuild.Append(this.pwd);
            csBuild.Append(";");
            string connectString = csBuild.ToString();
            //string connectString = (@"Data Source = ASPIRE-5560G\ZLSQL; Initial Catalog = DBSlides; User Id = @login; Password = @password;");
            SqlConnection db = new SqlConnection();
            db.ConnectionString = connectString;

            return db;
        }
    }
}
