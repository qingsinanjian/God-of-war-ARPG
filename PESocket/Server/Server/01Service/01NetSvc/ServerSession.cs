//网络会话连接

using System;
using PENet;
using PEProtocol;

public class ServerSession : PESession<GameMsg>
{
    public int sessionID = 0;
    protected override void OnConnected()
    {
        sessionID = ServerRoot.Instance.GetSessionID();
        PECommon.Log("SessionID:" + sessionID + " Client Connect");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("SessionID:" + sessionID + " RcvPack CMD:" + ((CMD)msg.cmd).ToString());
        MsgPack pack = new MsgPack(this, msg);
        NetSvc.Instance.AddMsgQue(pack);
    }

    protected override void OnDisConnected()
    {
        LoginSys.Instance.ClearOffLineData(this);
        PECommon.Log("SessionID:" + sessionID + " Client OffLine");
    }
}

