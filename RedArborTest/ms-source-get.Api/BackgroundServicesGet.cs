using ms_source_get.Domain.Dto;
using ms_source_get.Domain.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using ms_source_get.Domain.Contracts;
using ms_source_get.Api.Controllers;

namespace ms_source_get.Api
{
    public class BackgroundServicesGet : IHostedService, IDisposable
    {
        private readonly IInsertRepository _insertRepository;
        private readonly IDeleteRepository _deleteRepository;
        private readonly IUpdateRepository _updateRepository;
        private readonly ILogger<BackgroundServicesGet> _logger;
        private MQSettings? _mQSettings;
        private IModel? _channel;
        private IConnection? _connection;
        private bool disposed = false;

        public BackgroundServicesGet(IInsertRepository insertRepository, IDeleteRepository deleteRepository, IUpdateRepository updateRepository, ILogger<BackgroundServicesGet> logger)
        {
            _insertRepository=insertRepository;
            _deleteRepository=deleteRepository;
            _updateRepository=updateRepository;
            _logger=logger;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _channel?.Dispose();
                    _connection?.Dispose();
                }

                disposed = true;
            }
        }

        public void StopConsume()
        {
            _channel?.Abort();
        }

        public void StartConsume(MQSettings mQSettings)
        {
            try
            {
                _mQSettings = mQSettings;

                var factory = new ConnectionFactory
                {
                    HostName = _mQSettings.Host,
                    Port = _mQSettings.Port,
                    UserName = _mQSettings.UserName,
                    Password = _mQSettings.Password
                };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: "CreateEmpleados", durable: false, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueDeclare(queue: "DeleteEmpleados", durable: false, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueDeclare(queue: "UpdateEmpleados", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += Consumer_Received;

                _channel.BasicConsume(queue: "CreateEmpleados", autoAck: true, consumer: consumer);             
                _channel.BasicConsume(queue: "DeleteEmpleados", autoAck: true, consumer: consumer);
                _channel.BasicConsume(queue: "UpdateEmpleados", autoAck: true, consumer: consumer);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error StartConsume");
            }
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            try
            {
                var validar = e.RoutingKey;
                byte[] body = e.Body.ToArray();
                string payload = Encoding.UTF8.GetString(body);
                Employee employee;
                if (!string.IsNullOrEmpty(payload))
                {
                    employee = JsonConvert.DeserializeObject<Employee>(payload);
                    switch (validar)
                    {
                        case "CreateEmpleados":
                            _insertRepository.CreateEmployee(employee);
                            break;
                        case "DeleteEmpleados":
                            _deleteRepository.DeleteEmployee(employee);
                            break;
                        case "UpdateEmpleados":
                            _updateRepository.UpdateEmployee(employee);
                            break;
                        default:
                            break;
                    }
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error Consumer_Received");
            }
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                StartConsume(MQSettingBuilder.Build());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error StartAsync");
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                StopConsume();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error StartAsync");
            }
            return Task.CompletedTask;
        }
    }
}
