//网络会话连接

using System;
using PENet;
using PEProtocol;

public class ServerSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PETool.LogMsg("Client Connect");
        SendMsg(new GameMsg()
        {
            text = "Welcome to Connect."
        });
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PETool.LogMsg("Client Req:" + msg.text);
        SendMsg(new GameMsg()
        {
            text = "Srv Rsp:" + msg.text
        });
    }

    protected override void OnDisConnected()
    {
        PETool.LogMsg("Client DisConnect");
    }
}

