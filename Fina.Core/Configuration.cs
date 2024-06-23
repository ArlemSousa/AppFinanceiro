using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core
{

    public static class Configuration
    {
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;
        public const int DefaultStatus = 200;

        public static string BackendUrl { get; set; } = "http://localhost:5250";
        public static string FrontendUrl { get; set; } = "http://localhost:5200";
    }
}
