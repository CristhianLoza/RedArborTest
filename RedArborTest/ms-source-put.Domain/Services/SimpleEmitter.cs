using ms_source_put.Domain.Dto;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ms_source_put.Domain.Services
{
    public class SimpleEmitter
    {        
        public static bool SendMessage<T>(T data, MQSettings mQSettings, string queueName)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = mQSettings.Host,
                    Port = mQSettings.Port,
                    UserName = mQSettings.UserName,
                    Password = mQSettings.Password
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                        string payload = JsonConvert.SerializeObject(data);
                        byte[] body = Encoding.UTF8.GetBytes(payload);

                        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Agregar LOG
                return false;                
            }
        }
    }
}
