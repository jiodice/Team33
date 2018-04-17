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
        public static string DeviceId;
        private const string ConnectionString = "HostName=Team33Hub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=jOMoVfLXXRadyke4fHP1M7K71PO/k21vYDFy+NDWnCU=";
        private const string IotHubUri = "Team33Hub.azure-devices.net";
        private static DeviceClient _deviceClient;
        public static void Main(string[] args)
        {
            //Setup device in Azure
            DeviceId = "Team33 Device [" + Environment.MachineName + "]";
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