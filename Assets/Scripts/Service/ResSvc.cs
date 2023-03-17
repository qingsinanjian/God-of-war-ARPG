/****************************************************
文件：ResSvc.cs
作者：吴炯鑫
日期：2023/3/16 19:33:21
功能：资源加载服务
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour 
{
    public static ResSvc Instance = null;
    public void InitSvc()
    {
        Instance= this;
        Debug.Log("Init ResSvc...");
    }

    private Action prgCB;

    public void LoadSceneAsync(string sceneName, Action loaded)
    {
        GameRoot.Instance.loadingWnd.SetWndState(true);

        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWnd.SetProgress(val);
            if (val == 1)
            {
                if(loaded != null)
                {
                    loaded();
                }
                prgCB = null;
                sceneAsync = null;
                GameRoot.Instance.loadingWnd.SetWndState(false);
            }
        };
        
    }

    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }
}