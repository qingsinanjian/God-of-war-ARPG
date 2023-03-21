/****************************************************
    文件：GameStart.cs
	作者：吴炯鑫
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using PENet;
using Protocal;

public class GameStart : MonoBehaviour 
{
    PESocket<ClientSession, NetMsg> client = null;
    private void Start()
    {
        client = new PESocket<ClientSession, NetMsg>();
        client.StartAsClient(IPCfg.srvIP, IPCfg.srvPort);
        client.SetLog(true, (string msg, int lv) =>
        {
            switch (lv)
            {
                case 0:
                    msg = "Log:" + msg;
                    Debug.Log(msg);
                    break;
                case 1:
                    msg = "Warn:" + msg;
                    Debug.LogWarning(msg);
                    break;
                case 2:
                    msg = "Error:" + msg;
                    Debug.LogError(msg);
                    break;
                case 3:
                    msg = "Info:" + msg;
                    Debug.Log(msg);
                    break;
            }
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            client.session.SendMsg(new NetMsg()
            {
                text = "hello unity"
            });
        }
    }
}