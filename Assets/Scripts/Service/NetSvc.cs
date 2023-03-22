/****************************************************
    文件：NetSvc.cs
	作者：吴炯鑫
    日期：2023/3/21 22:41:55
	功能：网络服务
*****************************************************/

using UnityEngine;
using PENet;
using PEProtocol;

public class NetSvc : MonoBehaviour 
{
    public static NetSvc Instance = null;
    private PESocket<ClientSession, GameMsg> client = null;

    public void Init()
    {
        Instance = this;
        client = new PESocket<ClientSession, GameMsg>();
        
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
        client.StartAsClient(SrvCfg.srvIP, SrvCfg.srvPort);
        PECommon.Log("Init NetSvc...");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            client.session.SendMsg(new GameMsg()
            {
                text = "hello unity"
            });
        }
    }
}