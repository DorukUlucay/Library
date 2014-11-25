using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class MsSql : IDataLayer
    {
        SqlConnection Conn = null;
        string _ConnectionString;

        public MsSql(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            Conn = new SqlConnection(_ConnectionString);
        }

        public void Insert(string[] ColumnNames, List<DataLayer.DataParameter> Values, string TableName)
        {
            string Command = "INSERT INTO " + TableName + " (";

            foreach (string colName in ColumnNames)
            {
                Command += colName + ",";
            }
            Command = Command.TrimEnd(',');
            Command += ") VALUES(";

            foreach (string colName in ColumnNames)
            {
                Command += "@" + colName + ",";
            }
            Command = Command.TrimEnd(',');
            Command += ")";

            using (Conn)
            {
                SqlCommand _COMMAND = new SqlCommand(Command, Conn);
                foreach (DataLayer.DataParameter item in Values)
                {
                    _COMMAND.Parameters.Add(new SqlParameter() { Value = item.Value, ParameterName = item.Name, DbType = item.Type});
                }
                Conn.Open();
                _COMMAND.ExecuteNonQuery();
            }
        }

        public DataTable SelectDataTable(string Command)
        {
            DataTable DT = new DataTable();
            //burada using kullanmıştım. ama dataaccessmanager için de using kullanınca dispose ediliyor
            //TODO:bir yol bul(belki bu durumda try daha iyidir)
            try
            {
                Conn.Open();
                SqlDataAdapter DA = new SqlDataAdapter(Command, Conn);
                DA.Fill(DT);
                Conn.Close();
            }
            catch (Exception)
            {
                Conn.Close();
                throw;
            }
            return DT;
        }

        public void Update(List<DataLayer.DataParameter> Values, List<DataLayer.DataParameter> Criterias, string TableName)
        {
            string Command = "UPDATE [" + TableName + "] SET ";
            foreach (DataLayer.DataParameter p in Values)
            {
                Command += p.Name + " = @" + p.Name + ", ";
            }
            Command = Command.Trim().TrimEnd(',');
            Command += " WHERE ";
            foreach (DataLayer.DataParameter c in Criterias)
            {
                Command += c.Name + "= @" + c.Name + ", ";
            }
            Command = Command.Trim().TrimEnd(',');
            using (Conn)
            {
                SqlCommand _COMMAND = new SqlCommand(Command, Conn);
                foreach (DataLayer.DataParameter item in Values)
                {
                    _COMMAND.Parameters.Add(new SqlParameter() { Value = item.Value, ParameterName = item.Name, DbType = item.Type });
                }
                foreach (DataLayer.DataParameter item in Criterias)
                {
                    _COMMAND.Parameters.Add(new SqlParameter() { Value = item.Value, ParameterName = item.Name, DbType = item.Type });
                }
                Conn.Open();
                _COMMAND.ExecuteNonQuery();
            }
        }

        public void Delete(List<DataLayer.DataParameter> Parameters, string TableName)
        {
            string Command = "DELETE FROM " + TableName + " WHERE ";
            foreach (DataLayer.DataParameter _P in Parameters)
            {
                Command += _P.Name + "=@" + _P.Name;
            }
            Command = Command.Trim().TrimEnd(',');
            using (Conn)
            {
                SqlCommand _COMM = new SqlCommand(Command, Conn);
                foreach (DataLayer.DataParameter _p in Parameters)
                {
                    _COMM.Parameters.Add(new SqlParameter() { Value = _p.Value, ParameterName = _p.Name, DbType = _p.Type });
                }
                Conn.Open();
                _COMM.ExecuteNonQuery();
            }
        }
    }
}
