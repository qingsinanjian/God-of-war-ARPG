/****************************************************
文件：CreateWnd.cs
作者：吴炯鑫
日期：2023/3/18 2:12:0
功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class CreateWnd : WindowRoot 
{
    public InputField iptName;
    protected override void InitWnd()
    {
        base.InitWnd();
        //TODO 生成随机名字
        iptName.text = resSvc.GetRDNameData(false);
    }

    public void ClickRDNameBtn()
    {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);
        iptName.text = resSvc.GetRDNameData();
    }

    public void ClickEnterBtn()
    {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);
        if(iptName.text != "")
        {
            //TODO 发送名字数据到服务器，登录主城
        }
        else
        {
            GameRoot.AddTips("当前名字不符合规范");
        }
    }
}