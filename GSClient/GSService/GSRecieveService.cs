
using System.Collections.Concurrent;


namespace GSService;

    public class GSRecieveService
    {
    static ConcurrentQueue<byte[]> incomingQueue = new();
    public GSRecieveService()
    {
        ProcessTelemetryQueue(CancellationToken.None);
    }
    public void EnqueDataToIncomingQueue(byte[] readData)
    {
        incomingQueue.Enqueue(readData);

    }
    private async void  ProcessTelemetryQueue(CancellationToken cancellationToken)
    {
        while(!cancellationToken.IsCancellationRequested)
        {
           while(incomingQueue.Count > 0)
            {
                if(incomingQueue.TryDequeue(out byte[] temp))
                    Console.WriteLine($"{BitConverter.ToString(temp)}");
            }
            await Task.Delay(100,cancellationToken);
        }
    }
}

