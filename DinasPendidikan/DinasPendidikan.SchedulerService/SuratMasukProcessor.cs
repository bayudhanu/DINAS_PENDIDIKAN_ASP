using DinasPendidikan.Contracts;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

public class SuratMasukProcessor : BackgroundService
{
    private readonly IModel _channel;
    private readonly ILogger<SuratMasukProcessor> _logger;
    private readonly IConnection _connection;

    public SuratMasukProcessor(IModel channel, ILogger<SuratMasukProcessor> logger, IConnection connection)
    {
        _channel = channel;
        _logger = logger;
        _connection = connection;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Setup queue untuk menerima job
        _channel.ExchangeDeclare("suratmasuk.import", ExchangeType.Fanout, durable: true);
        var queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queueName, "suratmasuk.import", string.Empty);

        // Setup consumer
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            try
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var job = JsonSerializer.Deserialize<SuratMasukImportJob>(message);

                if (job == null) return;

                _logger.LogInformation($"Processing job {job.JobId}");

                // Simulasi proses yang lama
                await Task.Delay(5000);

                // Kirim notifikasi selesai
                var completedMessage = new SuratMasukImportCompleted
                {
                    JobId = job.JobId,
                    ProcessedRecords = 1000000 // Simulasi 1 juta record
                };

                var completedBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(completedMessage));
                _channel.BasicPublish(
                    exchange: "suratmasuk.status",
                    routingKey: string.Empty,
                    basicProperties: null,
                    body: completedBody);

                _logger.LogInformation($"Job {job.JobId} completed");

                // Hapus file temporary
                if (System.IO.File.Exists(job.FilePath))
                {
                    System.IO.File.Delete(job.FilePath);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing job");

                // Kirim notifikasi gagal jika diperlukan
            }
        };

        _channel.BasicConsume(
            queue: queueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}