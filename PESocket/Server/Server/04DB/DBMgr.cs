//数据库管理类

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
        PlayerData playerData = null;
        return playerData;
    }
    
}

