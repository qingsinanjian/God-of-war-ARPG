//网络通信协议（服务端客户端共用）
using System;
using PENet;

namespace PEProtocol
{
    [Serializable]
    public class GameMsg:PEMsg
    {
        public string text;
    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
