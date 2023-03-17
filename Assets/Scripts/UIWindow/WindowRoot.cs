/****************************************************
文件：WindowRoot.cs
作者：吴炯鑫
日期：2023/3/17 14:34:1
功能：UI界面基类
*****************************************************/

using UnityEngine;

public class WindowRoot : MonoBehaviour 
{
    public ResSvc resSvc;

    public void SetWndState(bool isActive = true)
    {
        if(gameObject.activeSelf != isActive)
        {
            gameObject.SetActive(isActive);
        }
        if (isActive)
        {
            InitWnd();
        }
        else
        {
            ClearWnd();
        }
    }

    protected virtual void InitWnd()
    {
        resSvc = ResSvc.Instance;
    }

    protected virtual void ClearWnd()
    {
        resSvc = null;
    }
}