//网络会话连接

using System;
using PENet;
using PEProtocol;

public class ServerSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PECommon.Log("Client Connect");
        SendMsg(new GameMsg()
        {
            text = "Welcome to Connect."
        });
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Client Req:" + msg.text);
        SendMsg(new GameMsg()
        {
            text = "Srv Rsp:" + msg.text
        });
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Client DisConnect");
    }
}

