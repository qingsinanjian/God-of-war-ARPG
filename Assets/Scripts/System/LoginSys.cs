/****************************************************
文件：LoginSys.cs
作者：吴炯鑫
日期：2023/3/16 19:32:37
功能：登录注册业务系统
*****************************************************/

using UnityEngine;
using PEProtocol;

public class LoginSys : SystemRoot 
{
    public static LoginSys Instance;
    public LoginWnd loginWnd;
    public CreateWnd createWnd;
    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
        PECommon.Log("Init LoginSys...");
    }

    /// <summary>
    /// 进入登录场景
    /// </summary>
    public void EnterLogin()
    {
        //TODO 异步加载登录场景
        resSvc.LoadSceneAsync(Constants.SceneLogin, OpenLoginWnd);
    }

    //显示加载进度条，加载完成后打开登录注册场景
    public void OpenLoginWnd()
    {
        loginWnd.SetWndState(true);
        audioSvc.PlayBGAudio(Constants.BGLogin);      
    }

    public void RspLogin(GameMsg msg)
    {
        GameRoot.AddTips("登录成功");
        GameRoot.Instance.SetPlayerData(msg.rspLogin);
        if(msg.rspLogin.playerData.name == "")
        {
            //打开角色创建界面
            createWnd.SetWndState(true);
        }
        else
        {
            //TODO
            //进入主城
        }
        //关闭登录界面
        loginWnd.SetWndState(false);
    }
}