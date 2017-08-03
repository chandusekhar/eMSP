using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVMSCoreLibrary
{
    public class JsonResult
    {
        public dynamic result { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
