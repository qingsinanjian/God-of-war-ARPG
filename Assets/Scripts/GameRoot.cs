/****************************************************
文件：GameRoot.cs
作者：吴炯鑫
日期：2023/3/16 19:29:17
功能：游戏启动入口
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour 
{
    public static GameRoot Instance = null;
    public LoadingWnd loadingWnd;
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        Debug.Log("Game Start");
        Init();
    }

    private void Init()
    {
        //服务模块初始化
        ResSvc resSvc = GetComponent<ResSvc>();
        resSvc.InitSvc();
        //业务系统初始化
        LoginSys loginSys = GetComponent<LoginSys>();
        loginSys.InitSys();

        //进入登录场景并加载相应UI
        loginSys.EnterLogin();

    }
}