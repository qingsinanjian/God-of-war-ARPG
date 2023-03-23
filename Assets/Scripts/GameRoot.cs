/****************************************************
文件：GameRoot.cs
作者：吴炯鑫
日期：2023/3/16 19:29:17
功能：游戏启动入口
*****************************************************/

using UnityEngine;
using PEProtocol;

public class GameRoot : MonoBehaviour 
{
    public static GameRoot Instance = null;
    public LoadingWnd loadingWnd;
    public DynamicWnd dynamicWnd;
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        PECommon.Log("Game Start");
        Init();
    }

    private void Init()
    {
        //服务模块初始化
        NetSvc netSvc = GetComponent<NetSvc>();
        netSvc.InitSvc();

        ResSvc resSvc = GetComponent<ResSvc>();
        resSvc.InitSvc();
        //声音播放服务初始化
        AudioSvc audioSvc = GetComponent<AudioSvc>();
        audioSvc.InitSvc();
        //业务系统初始化
        LoginSys loginSys = GetComponent<LoginSys>();
        loginSys.InitSys();

        ClearUIRoot();

        //进入登录场景并加载相应UI
        loginSys.EnterLogin();
    }

    private void ClearUIRoot()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        dynamicWnd.SetWndState(true);
    }

    public static void AddTips(string msg)
    {
        Instance.dynamicWnd.AddTips(msg);
    }

    private PlayerData playerData = null;

    public PlayerData PlayerData
    {
        get
        {
            return playerData;
        }
    }

    public void SetPlayerData(RspLogin data)
    {
        playerData = data.playerData;
    }
}