using RabbitMQ.Client;

namespace RabbitConsole
{
    public class Connection
    {
        public IConnection Connect()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };

            return connectionFactory.CreateConnection();
        }
    }
}
