using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitConsole
{
    public class Producer
    {
        private readonly Connection _connection;
        public Producer()
        {
            _connection = new Connection();
        }

        public void Send(User user)
        {
            using (var connection = _connection.Connect())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "User", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var userData = JsonConvert.SerializeObject(user);

                    var body = Encoding.UTF8.GetBytes(userData);

                    Console.WriteLine("Message sent");
                    channel.BasicPublish(exchange: "", routingKey: "User", basicProperties: null, body: body);
                }
            }
        }
    }
}