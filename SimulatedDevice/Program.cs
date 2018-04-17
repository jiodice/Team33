using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    class Program
    {    
        private const string DeviceId = "Team33-3";

        public static void Main(string[] args)
        {
            //Setup device in Azure
            DeviceIdentity.SetupDeviceAsync(DeviceId).Wait();

            public string devicePublicKey = DeviceIdentity.DevicePublicKey;
        }
    }
}