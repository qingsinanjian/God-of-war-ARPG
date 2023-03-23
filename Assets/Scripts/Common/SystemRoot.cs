/****************************************************
文件：SystemRoot.cs
作者：吴炯鑫
日期：2023/3/17 16:5:15
功能：业务系统基类
*****************************************************/

using UnityEngine;

public class SystemRoot : MonoBehaviour 
{
    protected ResSvc resSvc;
    protected AudioSvc audioSvc;
    protected NetSvc netSvc;
    
    public virtual void InitSys()
    {
        resSvc= GetComponent<ResSvc>();
        audioSvc= GetComponent<AudioSvc>();
        netSvc = GetComponent<NetSvc>();
    }
}