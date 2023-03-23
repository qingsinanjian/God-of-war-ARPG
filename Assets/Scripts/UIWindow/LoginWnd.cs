/****************************************************
文件：LoginWnd.cs
作者：吴炯鑫
日期：2023/3/17 14:8:53
功能：登录注册界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using PEProtocol;

public class LoginWnd : WindowRoot 
{
    public InputField iptAcct;
    public InputField iptPass;
    public Button btnEnter;
    public Button btnNotice;

    protected override void InitWnd()
    {
        base.InitWnd();
        if(PlayerPrefs.HasKey("Acct") && PlayerPrefs.HasKey("Pass"))
        {
            iptAcct.text = PlayerPrefs.GetString("Acct");
            iptPass.text = PlayerPrefs.GetString("Pass");
        }
        else
        {
            iptAcct.text = "";
            iptPass.text = "";
        }
    }

    //TODO 完成账号和密码的本地化存储

    /// <summary>
    /// 点击进入游戏
    /// </summary>
    public void ClickEnterBtn()
    {
        audioSvc.PlayUIAudio(Constants.UILoginBtn);
        string _acct = iptAcct.text;
        string _pass = iptPass.text;
        if(_acct != "" && _pass != "")
        {
            PlayerPrefs.SetString("Acct", _acct);
            PlayerPrefs.SetString("Pass", _pass);

            //TODO 发送网络消息，请求登录
            GameMsg msg = new GameMsg()
            {
                cmd = (int)CMD.ReqLogin,
                reqLogin = new ReqLogin()
                {
                    acct = _acct,
                    pass = _pass
                }
            };
            netSvc.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("账号或密码为空");
        }

    }

    public void ClickNoticeBtn()
    {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);
        GameRoot.AddTips("此功能正在开发中...");
    }
}