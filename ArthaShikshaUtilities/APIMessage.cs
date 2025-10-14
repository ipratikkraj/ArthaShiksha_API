using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaUtilities
{
    public class APIMessage
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object Data { get; set; }
    }
}
