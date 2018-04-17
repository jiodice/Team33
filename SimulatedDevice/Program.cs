using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedDevice
{
    class Program
    {
        private const string ConnectionString = "HostName=Team33Hub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=jOMoVfLXXRadyke4fHP1M7K71PO/k21vYDFy+NDWnCU=";
        private const string IotHubUri = "Team33Hub.azure-devices.net";
        private const string DeviceId = "Team33-2";
        private static DeviceClient _deviceClient;
        public static void Main(string[] args)
        {
            //Setup device in Azure
            DeviceIdentity.SetupDeviceAsync(DeviceId, ConnectionString).Wait();
            string devicePublicKey = DeviceIdentity.DevicePublicKey;
        }
        private static void StartSimulation(string devicePublicKey)
        {
            Console.WriteLine("Simulated device\n");
            _deviceClient = DeviceClient.Create(IotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(DeviceId, devicePublicKey), TransportType.Mqtt);
        }
    }
}