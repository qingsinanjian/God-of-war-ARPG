﻿//网络通信协议（服务端客户端共用）
using System;
using PENet;

namespace PEProtocol
{
    [Serializable]
    public class GameMsg:PEMsg
    {
        public ReqLogin reqLogin;
        public RspLogin rspLogin;
        public ReqRename reqRename;
        public RspRename rspRename;
    }

    #region 登录相关
    [Serializable]
    public class ReqLogin
    {
        public string acct;
        public string pass;
    }
    [Serializable]
    public class RspLogin
    {
        public PlayerData playerData;
    }

    [Serializable]
    public class PlayerData
    {
        public int id;
        public string name;
        public int lv;
        public int exp;
        public int power;
        public int coin;
        public int diamond;

        public int hp;
        public int ad;
        public int ap;
        public int addef;
        public int apdef;
        public int dodge;//闪避概率
        public int pierce;//穿透比率
        public int critical;//暴击概率
        //TOADD
    }

    [Serializable]
    public class ReqRename
    {
        public string name; 
    }

    [Serializable]
    public class RspRename
    {
        public string name;
    }
    #endregion

    public enum CMD
    {
        None,
        //登录相关 100
        ReqLogin = 101,
        RspLogin = 102,

        ReqRename = 103,
        RspRename = 104
    }

    public enum ErrorCode
    {
        None = 0,//没有错误
        AcctIsOnline,//账号已上线
        WrongPass,//密码错误
        NameIsExit,//名字已经存在
        UpdateDBError,//更新数据库错误
    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
