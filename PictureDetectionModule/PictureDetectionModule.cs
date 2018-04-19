using System.Text;
using Microsoft.Azure.Devices.Gateway;

namespace PictureDetectionModule
{
    public class PictureDetectionModule : IGatewayModule
    {
        private string configuration;

        // Creates a module using the specified configuration connecting to the specified message broker.
        public void Create(Broker broker, byte[] configuration)
        {
            this.configuration = Encoding.UTF8.GetString(configuration);
        }

        // Disposes of the resources allocated by/for this module.
        public void Destroy()
        {
        }

        // The module's callback function that is called upon message receipt.
        public void Receive(Message received_message)
        {
            string msg = null;

            if (received_message.Properties["source"] == "sensor")
            {
                msg = Encoding.UTF8.GetString(received_message.Content, 0, received_message.Content.Length);
            }
        }
    }
}
