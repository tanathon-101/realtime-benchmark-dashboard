const connection = new signalR.HubConnectionBuilder()
    .withUrl("/benchmarkHub")
    .build();

connection.on("ReceiveMetrics", data => {
    document.getElementById("mem").innerText = data.memoryUsageMB;
    document.getElementById("threads").innerText = data.threadCount;
    document.getElementById("g0").innerText = data.gen0;
    document.getElementById("g1").innerText = data.gen1;
    document.getElementById("g2").innerText = data.gen2;
});

connection.start().catch(err => console.error("SignalR failed:", err));
