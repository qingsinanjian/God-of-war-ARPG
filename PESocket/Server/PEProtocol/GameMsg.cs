//网络通信协议（服务端客户端共用）
using System;
using PENet;

namespace PEProtocol
{
    [Serializable]
    public class GameMsg:PEMsg
    {
        public ReqLogin reqLogin;
    }

    [Serializable]
    public class ReqLogin
    {
        public string acct;
        public string pass;
    }

    public enum CMD
    {
        None,
        //登录相关 100
        ReqLogin = 101,
        RspLogin = 102
    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
