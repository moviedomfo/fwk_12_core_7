using Fwk.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fwk.bases.services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICnnStringService
    {
        cnnStrings get_cnnStrings(List<ConnectionString> connectionStrings);
        ConnectionString get_cnnString_byName(string cnnStringName);
        void SetCnnStrings(ConnectionStrings cnnStrings);

    }
    
}
