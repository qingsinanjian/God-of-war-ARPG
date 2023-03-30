//登录业务系统
using PEProtocol;

public class LoginSys
{
    private static LoginSys instance;
    public static LoginSys Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new LoginSys();
            }
            return instance;
        }
    }

    private CacheSvc cacheSvc;

    public void Init()
    {
        cacheSvc = CacheSvc.Instance;
        PECommon.Log("LoginSys Init Done");
    }

    public void ReqLogin(MsgPack pack)
    {
        ReqLogin data = pack.msg.reqLogin;
        //当前账号是否已经上线
        GameMsg msg = new GameMsg()
        {
            cmd = (int)CMD.RspLogin,
            rspLogin = new RspLogin()
            {

            }
        };
        if (cacheSvc.IsAcctOnline(data.acct))
        {
            //已上线：返回错误信息
            msg.err = (int)ErrorCode.AcctIsOnline;
        }
        else
        {
            //未上线：
            //账号是否存在
            PlayerData pd = cacheSvc.GetPlayerData(data.acct, data.pass);
            if(pd == null)
            {
                //存在，密码错误
                msg.err = (int)ErrorCode.WrongPass;
            }
            else
            {
                msg.rspLogin = new RspLogin()
                {
                    playerData = pd
                };
                cacheSvc.AcctOnline(data.acct, pack.session, pd);
            }
        }
        //回应客户端
        pack.session.SendMsg(msg);
    }

    public void ReqRename(MsgPack pack)
    {
        ReqRename reqRename = pack.msg.reqRename;
        GameMsg msg = new GameMsg()
        {
            cmd = (int)CMD.RspRename
        };

        if (cacheSvc.IsNameExist(reqRename.name))
        {
            //名字是否已经存在
            //存在：返回错误码
            msg.err = (int)ErrorCode.NameIsExit;
        }
        else
        {
            //不存在：更新缓存以及数据库再返回客户端
            PlayerData playerData = cacheSvc.GetPlayerDataBySession(pack.session);
            playerData.name = reqRename.name;
            if(!cacheSvc.UpdatePlayerData(playerData.id, playerData))
            {
                msg.err = (int)ErrorCode.UpdateDBError;
            }
            else
            {
                msg.rspRename = new RspRename()
                {
                    name = reqRename.name
                };
            }
        }
        pack.session.SendMsg(msg);
    }

    public void ClearOffLineData(ServerSession session)
    {
        cacheSvc.AcctOffLine(session);
    }
}

