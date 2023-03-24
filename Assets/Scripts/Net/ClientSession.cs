/****************************************************
    文件：ClientSession.cs
	作者：吴炯鑫
    日期：2023/3/21 22:47:44
	功能：客户端网络会话
*****************************************************/

using UnityEngine;
using PENet;
using PEProtocol;

public class ClientSession:PESession<GameMsg>
{
    protected override void OnConnected()
    {
        GameRoot.AddTips("连接服务器成功");
        PECommon.Log("Connect To Server Succ");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        NetSvc.Instance.AddNetPkg(msg);
        PECommon.Log("RcvPack CMD :" + ((CMD)msg.cmd).ToString());
    }

    protected override void OnDisConnected()
    {
        GameRoot.AddTips("服务器断开连接");
        PECommon.Log("DisConnect To Server");
    }
}