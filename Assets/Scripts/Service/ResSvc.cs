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

    public void LoadSceneAsync(string sceneName)
    {
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWnd.SetProgress(val);
            if (val == 1)
            {
                prgCB = null;
                sceneAsync = null;
                GameRoot.Instance.loadingWnd.gameObject.SetActive(false);
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