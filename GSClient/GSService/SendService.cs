
using System.Collections.Concurrent;

namespace GSService;

   public class SendService
    {
    public GSConnection GSConnection { get; set; }
    static ConcurrentQueue<byte[]> realOutgoingQueue=new();
    public SendService(GSConnection gSConnection)
    {
        
      
       ProcessSendQueue(CancellationToken.None);
        //GSConnection = gSConnection;
    }

    

    public void EnqueDataInrealoutgoing(byte[] sendCommand)//MissionPUSTelecommandInfo CommandList
    {
        if (sendCommand != null)
       
             realOutgoingQueue.Enqueue(sendCommand);
    }
    private async  void ProcessSendQueue(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (realOutgoingQueue == null)
                continue;
            if (realOutgoingQueue.Count > 0)
            {
                realOutgoingQueue.TryDequeue(out byte[] temp);
                if (temp.Length == 0 || temp == null)
                    continue;
                if (await GSConnection.WriteData(temp))
                {
                 //change tc status  var result=await _gSConnection.WriteData(temp);
                }

            }
            await Task.Delay(10,cancellationToken);
        }
    }
    }

