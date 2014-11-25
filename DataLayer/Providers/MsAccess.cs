using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace DataLayer
{
    public class MsAccess : IDataLayer
    {
        OleDbConnection Conn = null;
        string _ConnectionString;

        public MsAccess(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            Conn = new OleDbConnection(_ConnectionString);
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
                OleDbCommand _COMMAND = new OleDbCommand(Command, Conn);
                foreach (DataLayer.DataParameter item in Values)
                {
                    OleDbParameter P = new OleDbParameter() { Value = item.Value, DbType = item.Type, ParameterName = item.Name };
                    _COMMAND.Parameters.Add(P);
                }
                Conn.Open();
                _COMMAND.ExecuteNonQuery();
            }
        }

        public DataTable SelectDataTable(string Command)
        {
            DataTable DT = new DataTable();
            using (Conn)
            {
                OleDbDataAdapter DA = new OleDbDataAdapter(Command, Conn);
                Conn.Open();
                DA.Fill(DT);
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
                OleDbCommand _COMMAND = new OleDbCommand(Command, Conn);
                foreach (DataLayer.DataParameter item in Values)
                {
                    OleDbParameter P = new OleDbParameter() { Value = item.Value, DbType = item.Type, ParameterName = item.Name };
                    _COMMAND.Parameters.Add(P);
                }
                foreach (DataLayer.DataParameter item in Criterias)
                {
                    OleDbParameter P = new OleDbParameter() { Value = item.Value, DbType = item.Type, ParameterName = item.Name };
                    _COMMAND.Parameters.Add(P);
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
                OleDbCommand _COMM = new OleDbCommand(Command, Conn);
                foreach (DataLayer.DataParameter _p in Parameters)
                {
                    OleDbParameter P = new OleDbParameter() { Value = _p.Value, DbType = _p.Type, ParameterName = _p.Name };
                    _COMM.Parameters.Add(P);
                }
                Conn.Open();
                _COMM.ExecuteNonQuery();
            }
        }
    }
}
