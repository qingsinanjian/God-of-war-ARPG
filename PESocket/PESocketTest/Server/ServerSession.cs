using PENet;
using Protocal;

namespace Server
{
    class ServerSession:PESession<NetMsg>
    {
        protected override void OnConnected()
        {
            PETool.LogMsg("Client Connect");
            SendMsg(new NetMsg()
            {
                text = "Welcome to Connect."
            });
        }

        protected override void OnReciveMsg(NetMsg msg)
        {
            PETool.LogMsg("Client Req:" + msg.text);
            SendMsg(new NetMsg()
            {
                text = "Srv Res:" + msg.text
            });
        }

        protected override void OnDisConnected()
        {
            PETool.LogMsg("Client DisConnect");
        }
    }
}
