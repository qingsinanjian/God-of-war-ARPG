//缓存层
using PEProtocol;
using System.Collections.Generic;

public class CacheSvc
{
    private static CacheSvc instance = null;
    public static CacheSvc Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new CacheSvc();
            }
            return instance;
        }
    }

    private DBMgr dbMgr = null;
    private Dictionary<string, ServerSession> onLineAcctDic = new Dictionary<string, ServerSession>();
    private Dictionary<ServerSession, PlayerData> onLineSessionDic = new Dictionary<ServerSession, PlayerData>();

    public void Init()
    {
        dbMgr = DBMgr.Instance;
        PECommon.Log("CacheSvc Init Done");
    }

    public bool IsAcctOnline(string acct)
    {
        return onLineAcctDic.ContainsKey(acct);
    }

    /// <summary>
    /// 根据账号密码返回对应账号数据，密码错误返回null，账号不存在则默认创建新账号
    /// </summary>
    public PlayerData GetPlayerData(string acct, string pass)
    {
        //从数据库中查找账号数据
        return dbMgr.QueryPlayerData(acct, pass);
    }

    /// <summary>
    /// 账号上线缓存数据
    /// </summary>
    public void AcctOnline(string acct, ServerSession session, PlayerData playerData)
    {
        onLineAcctDic.Add(acct, session);
        onLineSessionDic.Add(session, playerData);
    }

    public bool IsNameExist(string name)
    {
        return dbMgr.QueryNameByData(name);
    }

    public PlayerData GetPlayerDataBySession(ServerSession session)
    {
        if(onLineSessionDic.TryGetValue(session, out PlayerData playerData))
        {
            return playerData;
        }
        else
        {
            return null;
        }
    }

    public bool UpdatePlayerData(int id, PlayerData pd)
    {
        dbMgr.UpdatePlayerData(id, pd);
        return true;
    }

    public void AcctOffLine(ServerSession session)
    {
        foreach (var item in onLineAcctDic)
        {
            if(item.Value == session)
            {
                onLineAcctDic.Remove(item.Key);
                break;
            }
        }

        bool succ = onLineSessionDic.Remove(session);
        PECommon.Log("OffLine Result:SessionID:" + session.sessionID + " " + succ);
    }
}

