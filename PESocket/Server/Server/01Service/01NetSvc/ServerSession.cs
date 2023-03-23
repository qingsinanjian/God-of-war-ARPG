//网络会话连接

using System;
using PENet;
using PEProtocol;

public class ServerSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PECommon.Log("Client Connect");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("RcvPack CMD:" + ((CMD)msg.cmd).ToString());
        MsgPack pack = new MsgPack(this, msg);
        NetSvc.Instance.AddMsgQue(pack);
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Client DisConnect");
    }
}

