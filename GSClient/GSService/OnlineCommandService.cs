using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSService;

    public class OnlineCommandService
    {
    private readonly SendService _sendService;
    private readonly GSRecieveService _gSRecieveService;
    private readonly GSConnection _gSConnection;
    private readonly byte[] senddata = {01,02,03,10,30,5,34,11,12,13,14,15,16,17,18,20,25,45,55,66};

    public OnlineCommandService(SendService sendService,GSRecieveService gSRecieveService,GSConnection gSConnection)
    {
       _sendService = sendService;
       _gSRecieveService = gSRecieveService;
       _gSConnection = gSConnection;
        _gSConnection.MakeConnectionToGS();
        _sendService.GSConnection = _gSConnection;
    }

    public async void SendData(CancellationToken cancellationToken)
    {
        while(!cancellationToken.IsCancellationRequested)
        { if (senddata != null)
            {
                _sendService.EnqueDataInrealoutgoing(senddata);
               // _sendService.ProcessSendQueue(CancellationToken.None);
            }
           await Task.Delay(100,cancellationToken);
        }
    }
    public async void RecieveData(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            byte[] readData = await _gSConnection.ReadData();
            if (readData != null)
                _gSRecieveService.EnqueDataToIncomingQueue(readData);
            await Task.Delay(100,cancellationToken);
        }
            
        }
    }


