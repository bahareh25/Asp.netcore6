using System.Net.Sockets;
namespace GSService ;

    public class GSConnection
{
    public static TcpClient client;
    //private EncryptDecrypt testenct = new EncryptDecrypt();

    public GSConnection()
    {
        // m_GSStatusBLL = new GSStatusBLL();
    }

    ~GSConnection()
    {

    }

    public virtual void Dispose()
    {

    }

    public void ConnectionRequest()
    {

    }

    /// 
    /// <param name="gsId"></param>
    public bool MakeConnectionToGS(int gsId)
    {

        return true;
    }

    /// 
    public bool MakeConnectionToGS()//string gsName
    {

        try
        {
            //GSInfo gs = new GSInfo();
            //gs = m_GSStatusBLL.GetGSList_byGsname(1, SatInfo.gsname);

            if (client == null)
            {

                // client = new TcpClient(gs.GsIp, Convert.ToInt32(gs.GsPort));//192.168.12.44 //192.168.12.14//127.0.0.1//99952
                client = new TcpClient("127.0.0.1", 3333);
                //Console.WriteLine("GsIP={0},gsPort={1}", gs.GsIp, gs.GsPort);
                return true;//127.0.0.1
            }
            if (client.Connected)
            {
                Console.WriteLine("connection to server is ok");
                return true;
            }
        }
        catch
        {
            Console.WriteLine("Cannot connect to server");

            //client = new TcpClient("127.0.0.1",4444); 
        }
        return false;
    }
    // int count = 0;

    /// <param name="PUSTelecommand"></param>
    public async Task<bool> WriteData(Byte[] temp)//PUSTelecommandInfo
    {
        try
        {
            NetworkStream stream = client.GetStream();

            //await stream.WriteAsync(temp.msg, 0, temp.msg.Length);
            // // count++;

            // for (int k = 0; k < temp.msg.Length; k++)
            // {
            //     Console.Write("{0:X}, ", temp.msg[k]);

            // }
            await stream.WriteAsync(temp, 0, temp.Length);
            // count++;


            Console.WriteLine($"{BitConverter.ToString(temp)}");



            // Console.WriteLine("message.Lengh={0}", temp.msg.Length);
            Console.WriteLine("message.Lengh={0}", temp.Length);
            Console.WriteLine("WriteData To GCS ");

            return true;
        }
        catch (NullReferenceException)
        {
            if (temp != null)
            {
                Console.WriteLine("Cannot Write to GS");
                //client.Close();
                //client = null;
                this.MakeConnectionToGS();
            }
            return false;

        }
        catch (IOException)
        {
            Console.WriteLine("Cannot connect to IO");
            client = null;
            this.MakeConnectionToGS();

            // client=null;
            return false;
        }
        catch (InvalidOperationException)
        {
            client.Close();
            client = null;
            this.MakeConnectionToGS();
            return false;

        }
    }

    public async Task<byte[]> ReadData()
    {
        Byte[] bytesreceive = new Byte[256];
        int bytes = 1;

        try
        {
            if (client.Connected)
            {
                byte[] datalengh = new byte[2];
                UInt16 datalen;
                NetworkStream stream = client.GetStream();

                bytes = await stream.ReadAsync(bytesreceive, 0, bytesreceive.Length);

                datalengh[0] = bytesreceive[4];
                datalengh[1] = bytesreceive[5];
                datalen = System.BitConverter.ToUInt16(datalengh, 0);
                Byte[] temp = new byte[datalen + 6];



                if (datalen > 0)
                {
                    Buffer.BlockCopy(bytesreceive, 0, temp, 0, datalen + 6);
                    //for (int i = 0; i < datalen + 6; i++)
                    //{
                    //    temp[i] = bytesreceive[i];
                    //}
                    Console.WriteLine();
                    //for (int k = 0; k < temp.Length; k++)
                    //{
                    //   Console.Write("{0:X}, ", temp[k]);
                    //}
                    Console.Write($"{BitConverter.ToString(temp)}");
                    Console.WriteLine();
                    Console.WriteLine("Recieved Data Length={0}", temp.Length);
                    return temp;
                }
                else
                {
                    client = null;
                    Console.WriteLine("data is garbage");
                }
            }

            else
            {
                Console.WriteLine("Client Not Connected");
            }
        }
        catch (NullReferenceException)
        {
            client = null;
            Console.WriteLine("Can not connect to server1");
        }
        catch (IOException)
        {
            client.Close();
            client = null;
            this.MakeConnectionToGS();
            Console.WriteLine("Can not connect to server1");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            client.Close();
            client = null;
        }
        return null;

    }
} 

