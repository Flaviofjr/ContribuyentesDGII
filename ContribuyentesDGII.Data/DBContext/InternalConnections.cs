using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContribuyentesDGII.Data.DBContext
{
    public static class InternalConnections
    {
        public static string? ConnectionString { get; set; }
        public static string? ApiBaseEndpoint { get; set; }
    }
}
