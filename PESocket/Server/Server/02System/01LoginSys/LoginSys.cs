//登录业务系统

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

    public void Init()
    {
        PECommon.Log("LoginSys Init Done");
    }
}

