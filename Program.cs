using System;

namespace RabbitConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool quitNow = default(bool);

            Console.WriteLine("Producer mode: 1 \nConsumer mode: 2 \n");

            while (!quitNow)
            {
                int consoleData = Convert.ToInt32(Console.ReadLine());

                switch ((Commands)consoleData)
                {
                    case Commands.producer:
                        var producer = new Producer();
                        producer.Send(new User()
                        {
                            Id = 1,
                            Name = "Sinan",
                            Email = "test@test.com"
                        });
                        break;
                    case Commands.consumer:
                        var consumer = new Consumer();
                        consumer.Start();
                        break;
                    case Commands.exit:
                        quitNow = true;
                        break;
                }
            }
        }
    }
}