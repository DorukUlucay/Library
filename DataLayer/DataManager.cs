using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataManager
    {
        private IDataLayer _DataLayer = null;

        public DataManager(string ConnectionType, string ConnectionString)
        {
            if (_DataLayer == null)
            {
                _DataLayer = DataLayerFactory.Create(ConnectionType, ConnectionString);
            }
        }

        public void Insert(string[] ColumnNames, List<DataLayer.DataParameter> Values, string TableName)
        {
            _DataLayer.Insert(ColumnNames, Values, TableName);
        }

        public void Update(List<DataLayer.DataParameter> Values, List<DataLayer.DataParameter> Criterias, string TableName)
        {
            _DataLayer.Update(Values, Criterias, TableName);
        }

        public void Delete(List<DataLayer.DataParameter> Parameters, string TableName)
        {
            _DataLayer.Delete(Parameters, TableName);
        }

        public DataTable SelectDataTable(string Command)
        {
            return _DataLayer.SelectDataTable(Command);
        }
         
    }
}
