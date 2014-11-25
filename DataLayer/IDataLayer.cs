using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataLayer
    {
        void Insert(string[] ColumnNames, List<DataLayer.DataParameter> Parameters, string TableName);
        DataTable SelectDataTable(string Command);
        void Delete(List<DataLayer.DataParameter> Parameters, string TableName);
        void Update(List<DataLayer.DataParameter> Values, List<DataLayer.DataParameter> Criterias, string TableName);
    }
}
