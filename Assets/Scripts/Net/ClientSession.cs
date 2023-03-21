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
        Debug.Log("Server Connect");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        Debug.Log("Server Req:" + msg.text);
    }

    protected override void OnDisConnected()
    {
        Debug.Log("Server DisConnect");
    }
}