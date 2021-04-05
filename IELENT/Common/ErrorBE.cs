using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Common
{
    [Serializable]
    public class ErrorBE
    {
        public StringBuilder psMensaje { get; set; }
        public bool pbFlag { get; set; }
    }
}
