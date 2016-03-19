using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{
    class ONItem
    {
        public string device;
        public ONItem(string device)
        {
            this.device = device;
        }

        public ONItem()
        {
            // TODO: Complete member initialization
        }

        public string Device
        {
            get { return device; }
            set { device = value; }
        }
    }
}
