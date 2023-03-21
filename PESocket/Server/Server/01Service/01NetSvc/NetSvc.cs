//网络服务

public class NetSvc
{
    private static NetSvc instance;
    public static NetSvc Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new NetSvc();
            }
            return instance;
        }
    }

    public void Init()
    {

    }
}

