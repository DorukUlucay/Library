using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataLayer
    {
        void Insert(string[] ColumnNames, SqlParameter[] Values, string TableName);
        void Delete();
        void Update();
    }
}
