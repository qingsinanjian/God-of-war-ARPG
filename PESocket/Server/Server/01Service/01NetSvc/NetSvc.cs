//网络服务
using PENet;
using PEProtocol;
using System.Collections.Generic;

public class MsgPack
{
    public ServerSession session;
    public GameMsg msg;
    public MsgPack(ServerSession session, GameMsg msg)
    {
        this.session = session;
        this.msg = msg;
    }
}

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

    private Queue<MsgPack> msgPackQue = new Queue<MsgPack>();
    private static readonly string obj = "lock";

    public void Init()
    {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(SrvCfg.srvIP, SrvCfg.srvPort);
        PECommon.Log("NetSvc Init Done");
    }

    public void AddMsgQue(MsgPack pack)
    {
        lock (obj)
        {
            msgPackQue.Enqueue(pack);
        }
    }

    public void Update()
    {
        if(msgPackQue.Count > 0)
        {
            PECommon.Log("PackCount:" + msgPackQue.Count);
            lock (obj)
            {
                MsgPack pack = msgPackQue.Dequeue();
                HandOutMsg(pack);
            }
        }
    }

    private void HandOutMsg(MsgPack pack)
    {
        switch ((CMD)pack.msg.cmd)
        {
            case CMD.ReqLogin:
                LoginSys.Instance.ReqLogin(pack);
                break;
            case CMD.ReqRename:
                LoginSys.Instance.ReqRename(pack);
                break;
        }
    }
}

