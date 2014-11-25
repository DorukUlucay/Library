using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryUI.DataAccessLayer
{
    public class DataAccessManager : IDisposable
    {
        public DataLayer.DataManager _DataManager = null;

        public DataAccessManager()
        {
            _DataManager = new DataLayer.DataManager(
                ConfigurationManager.AppSettings["DataLayerType"].ToString(),
                ConfigurationManager.ConnectionStrings["LIBRARYEntitiesMSSQL"].ToString());
        }

        public void Dispose()
        {
            _DataManager = null;
            GC.Collect();
        }

        public void Insert(string[] ColumnNames, List<DataLayer.DataParameter> Values, string TableName)
        {
            _DataManager.Insert(ColumnNames, Values, TableName);
        }

        public DataTable SelectDataTable(string Command)
        {
            return _DataManager.SelectDataTable(Command);
        }

        public void Update(List<DataLayer.DataParameter> Values, List<DataLayer.DataParameter> Criterias, string TableName)
        {
            _DataManager.Update(Values, Criterias, TableName);
        }

        public void Delete(List<DataLayer.DataParameter> Parameters, string TableName)
        {
            _DataManager.Delete(Parameters, TableName);
        }
    }
}