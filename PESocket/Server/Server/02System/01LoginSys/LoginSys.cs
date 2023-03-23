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

    public void Init()
    {
        PECommon.Log("LoginSys Init Done");
    }

    public void ReqLogin(MsgPack pack)
    {
        //当前账号是否已经上线
            //已上线：返回错误信息
            //未上线：
                //账号是否存在
                    //存在，检测密码
                    //不存在，创建默认的账号密码
        //回应客户端

    }
}

