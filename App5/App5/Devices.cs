using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class Devices
    {
        public string device;
        public string usage;
        public string status;

        public Devices(string device, string usage, string status)
        {
            this.device = device;
            this.usage = usage;
            this.status = status;
        }

        public Devices()
        {

        }

        public string Device
            {
            get { return device; }
            set { device = value; }
            }

        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
