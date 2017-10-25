using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleServiceBusUsingTopics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SendMessageUsingTopics();
            RecieveMessageUsingTopics();
        }

        private static void SendMessageUsingTopics()
        {
            try
            {
                var connectionString = "Endpoint=sb://basicservicebus17oct.servicebus.windows.net/;SharedAccessKeyName=topic17oct;SharedAccessKey=4g5f0mAGF7+Ty0i6/KLB26AvwekDE0wUZfX70rVDr4k=";
                var topicName = "basictopic17oct";

                var client = TopicClient.CreateFromConnectionString(connectionString, topicName);
                var message = new BrokeredMessage("This is a test message!");

                Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));

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

        private static void RecieveMessageUsingTopics()
        {
            try
            {
                var connectionString = "Endpoint=sb://basicservicebus17oct.servicebus.windows.net/;SharedAccessKeyName=topic17oct;SharedAccessKey=4g5f0mAGF7+Ty0i6/KLB26AvwekDE0wUZfX70rVDr4k=";
                var topicName = "basictopic17oct";

                var client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, "JitendraMachine");

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
