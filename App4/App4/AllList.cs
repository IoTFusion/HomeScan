using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{
    public class AllDevice
    {
        public string device;
        public string status;
        public string usage;

        public AllDevice(string device, string status, string usage)
        {
            this.device = device;
            this.status = status;
            this.usage = usage;
            
        }

        public AllDevice()
        {
            // TODO: Complete member initialization
        }

        public string Device
        {
            get { return device; }
            set { device = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }

       
    }
}
