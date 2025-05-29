using Microsoft.AspNetCore.SignalR;
using src.Hubs;
using src.Model;
using System.Diagnostics;

public class BenchmarkService : BackgroundService
{
    private readonly IHubContext<BenchmarkHub> _hub;

    public BenchmarkService(IHubContext<BenchmarkHub> hub) => _hub = hub;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var process = Process.GetCurrentProcess();

        while (!stoppingToken.IsCancellationRequested)
        {
            var metrics = new BenchmarkMetrics
            {
                MemoryUsageMB = GC.GetTotalMemory(false) / 1024 / 1024,
                ThreadCount = process.Threads.Count,
                Gen0 = GC.CollectionCount(0),
                Gen1 = GC.CollectionCount(1),
                Gen2 = GC.CollectionCount(2)
            };

            await _hub.Clients.All.SendAsync("ReceiveMetrics", metrics);
            await Task.Delay(5000, stoppingToken);
        }
    }
}
