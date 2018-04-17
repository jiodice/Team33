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

        static async Task MainAsync(string[] args)
        {
            //Setup device in Azure
            string deviceId = await DeviceIdentity.SetupDeviceAsync(DeviceId);
            

        }
        private void donothing(){
            
        }
    }
}
