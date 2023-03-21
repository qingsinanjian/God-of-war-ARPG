﻿//服务器初始化
using System;

public class ServerRoot
{
    private static ServerRoot instance = null;
    public static ServerRoot Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ServerRoot();
            }
            return instance;
        } 
    }

    public void Init()
    {
        //数据层TODO

        //服务层
        NetSvc.Instance.Init();

        //业务系统层
        LoginSys.Instance.Init();
    }
}

