using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleServiceBus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SendMessageUsingQueue();
            RecieveMessageUsingQueue();
        }

        private static void SendMessageUsingQueue()
        {
            try
            {
                var connectionString = "Endpoint=sb://basicservicebus17oct.servicebus.windows.net/;SharedAccessKeyName=queue17oct;SharedAccessKey=v+j90RsKBlRnPaoqm/T4AURhgVHMauasNFpb0c5sScg=";
                var queueName = "basicqueue17oct";

                var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
                var message = new BrokeredMessage("This is a test message!");

                Console.WriteLine(String.Format("Message id: {0}", message.MessageId));

                client.Send(message);

                Console.WriteLine("Message successfully sent! Press ENTER to continue..");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void RecieveMessageUsingQueue()
        {
            try
            {
                var connectionString = "Endpoint=sb://basicservicebus17oct.servicebus.windows.net/;SharedAccessKeyName=queue17oct;SharedAccessKey=v+j90RsKBlRnPaoqm/T4AURhgVHMauasNFpb0c5sScg=";
                var queueName = "basicqueue17oct";

                var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

                client.OnMessage(message =>
                {
                    Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
                    Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
                });

                Console.WriteLine("Press ENTER to exit program");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
