using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManagerSystem.Application
{
    [Serializable]
   public class SendData
    {
        public byte[] option { get; set; }

        public byte[] data { get; set; }
    }
}
