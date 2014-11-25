using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataLayerFactory
    {
        public static IDataLayer Create(string DataLayerType, string ConnectionString)
        {
            IDataLayer dataLayer = null;
            Type T = Type.GetType(DataLayerType);
            object objectHandle = Activator.CreateInstance(T, ConnectionString);
            object obj = objectHandle;
            if (obj != null)
            {
                if (obj is IDataLayer)
                {
                    dataLayer = (IDataLayer)obj;
                }
                else
                {
                    throw new Exception(string.Format("Type '{0}' is not found.", DataLayerType));
                }
            }
            else
            {
                throw new Exception(string.Format("Type '{0}' can not be created.", DataLayerType));
            }
            return dataLayer;
        }
    }
}
