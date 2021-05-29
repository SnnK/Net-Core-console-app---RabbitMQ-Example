using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitConsole
{
    public class Consumer
    {
        private readonly Connection _connection;
        public Consumer()
        {
            _connection = new Connection();
        }

        public void Start()
        {
            var connection = _connection.Connect();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "User",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                string message = Encoding.UTF8.GetString(ea.Body.ToArray());

                var userData = JsonConvert.DeserializeObject<User>(message);

                Console.WriteLine($"Received message: {userData.Name} {userData.Email}");
            };

            channel.BasicConsume(queue: "User",
              autoAck: true,
              consumer: consumer);
        }
    }
}
