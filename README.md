# Net Core console app | RabbitMQ Example

``
docker run -d --hostname myrabbitmq --name rabbitmqforexample -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3.8.9-management
``
