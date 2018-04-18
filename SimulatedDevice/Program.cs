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
        private const string ConnectionString = "HostName=Team33HubEast.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=sp+bEjC8Rof2bEuwMZ+qW+/vtc03wKr3vcmXOYZKVp4=";
        private const string IotHubUri = "Team33HubEast.azure-devices.net";
        private static DeviceClient _deviceClient;
        public static void Main(string[] args)
        {
            //Setup device in Azure
            DeviceId = "Team33-Device-" + Environment.MachineName;
            DeviceIdentity.SetupDeviceAsync(DeviceId, ConnectionString).Wait();
            string devicePublicKey = DeviceIdentity.DevicePublicKey;
            StartSimulation(devicePublicKey);
        }
        private static void StartSimulation(string devicePublicKey)
        {
            Console.WriteLine("Simulated device\n");
            _deviceClient = DeviceClient.Create(IotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey(DeviceId, devicePublicKey), TransportType.Mqtt);
            SimulateMessage.SendMessagesAsync(_deviceClient);
            Console.ReadLine();
        }

    }
}