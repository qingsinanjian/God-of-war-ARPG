//数据库管理类

using System;
using MySql.Data.MySqlClient;
using PEProtocol;

public class DBMgr
{
    private static DBMgr instance = null;
    public static DBMgr Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new DBMgr();
            }
            return instance;
        }
    }
    private MySqlConnection conn = null;
    public void Init()
    {
        conn = new MySqlConnection("Server = localhost;User id = root;password=;Database=darkgod;Charset=utf8");
        PECommon.Log("DBMgr Init Done");
    }
    
    public PlayerData QueryPlayerData(string acct, string pass)
    {
        bool isNew = true;
        PlayerData playerData = null;
        MySqlDataReader reader = null;
        try
        {
            MySqlCommand cmd = new MySqlCommand("select * from account where acct = @acct", conn);
            cmd.Parameters.AddWithValue("acct", acct);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                isNew = false;
                string _pass = reader.GetString("pass");
                //密码正确，返回玩家数据
                if (_pass.Equals(pass))
                {
                    playerData = new PlayerData()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        lv = reader.GetInt32("level"),
                        exp = reader.GetInt32("exp"),
                        power = reader.GetInt32("power"),
                        coin = reader.GetInt32("coin"),
                        diamond = reader.GetInt32("diamond")
                        //TODO
                    };
                }
            }
        }
        catch (Exception e)
        {
            PECommon.Log("Query PlayerData By Acct&Pass Error:" + e, LogType.Error);
        }
        finally
        {
            if (isNew)
            {
                //不存在账号数据，创建新的默认账号数据，并返回
                playerData = new PlayerData()
                {
                    id = -1,
                    name = "",
                    lv = 1,
                    exp = 0,
                    power = 150,
                    coin = 5000,
                    diamond = 500
                    //TOADD
                };
                playerData.id = InsertNewAcctData(acct, pass, playerData);
            }
        }
        return playerData;
    }
    
    private int InsertNewAcctData(string acct, string pass, PlayerData pd)
    {
        return 0;
    }
}

