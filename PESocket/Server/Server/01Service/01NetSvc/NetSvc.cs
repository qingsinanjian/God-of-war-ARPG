//网络服务
using PENet;
using PEProtocol;

public class NetSvc
{
    private static NetSvc instance;
    public static NetSvc Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new NetSvc();
            }
            return instance;
        }
    }

    public void Init()
    {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(SrvCfg.srvIP, SrvCfg.srvPort);
        PETool.LogMsg("NetSvc Init Done");
    }
}

