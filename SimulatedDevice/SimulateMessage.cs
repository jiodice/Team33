using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimulatedDevice
{
    public static class SimulateMessage
    {
        public static async void SendMessagesAsync(Microsoft.Azure.Devices.Client.DeviceClient _deviceClient)
        {
            while (true)
            {
                var telemetryDataPoint = new
                {
                    ticketId = System.Guid.NewGuid(),
                    entryTime = DateTime.UtcNow
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));
                
                await _deviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                await Task.Delay(1000);
            }
        }
    }
}
