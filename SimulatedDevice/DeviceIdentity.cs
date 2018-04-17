using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;
//using Telemetry;

namespace SimulatedDevice
{
    class DeviceIdentity
    {
        public static string DevicePublicKey = null;
        private static RegistryManager _registryManager;
        private const string Name = "Team 33 Device ?";
        private const string TelemetryKey = "telemetry";
        private const string InstrumentationKey = "instrumentationKey";
        //private static Telemetry TelemetryClient;
        private static readonly Configuration Config = ConfigurationManager.OpenExeConfiguration(System.IO.Path.Combine(
            Environment.CurrentDirectory, System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name));

        public static async Task SetupDeviceAsync(string deviceId, string ConnectionString)
        {
            Device device;
            try
            {
                _registryManager = RegistryManager.CreateFromConnectionString(ConnectionString);
                device = await _registryManager.AddDeviceAsync(new Device(deviceId));
                SendTelemetry("success", "register new device");
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await _registryManager.GetDeviceAsync(deviceId);
                SendTelemetry("success", "device existed");
            }
            catch (Exception e)
            {
                SendTelemetry("failed", $"register device failed: {e.Message}");
                Console.WriteLine($"register device failed: {e.Message}");
                throw;
            }

            Console.WriteLine($"device key : {device.Authentication.SymmetricKey.PrimaryKey}");

            DevicePublicKey =  device.Authentication.SymmetricKey.PrimaryKey;
        }

        private static void SendTelemetry(string eventName, string message)
        {
            //if (TelemetryClient != null)
            //{
            //    bool shouldSend;
            //    bool.TryParse(Config.AppSettings.Settings[TelemetryKey].Value, out shouldSend);
            //    if (shouldSend)
            //    {
            //        TelemetryClient.Track(eventName, ConnectionString, Name, message);
            //    }
            //}
        }
    }
}
