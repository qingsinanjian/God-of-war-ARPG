/****************************************************
文件：LoginWnd.cs
作者：吴炯鑫
日期：2023/3/17 14:8:53
功能：登录注册界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoginWnd : WindowRoot 
{
    public InputField iptAcct;
    public InputField iptPass;
    public Button btnEnter;
    public Button btnNotice;

    protected override void InitWnd()
    {
        base.InitWnd();
        if(PlayerPrefs.HasKey("iptAcct") && PlayerPrefs.HasKey("iptPass"))
        {
            iptAcct.text = PlayerPrefs.GetString("iptAcct");
            iptPass.text = PlayerPrefs.GetString("iptPass");
        }
        else
        {
            iptAcct.text = "";
            iptPass.text = "";
        }
    }

    //TODO 完成账号和密码的本地化存储
}