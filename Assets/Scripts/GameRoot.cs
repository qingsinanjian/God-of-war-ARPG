/****************************************************
文件：GameRoot.cs
作者：吴炯鑫
日期：2023/3/16 19:29:17
功能：游戏启动入口
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour 
{
    private void Start()
    {
        Debug.Log("Game Start");
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