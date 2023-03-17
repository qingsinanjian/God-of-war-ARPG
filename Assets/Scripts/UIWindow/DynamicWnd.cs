/****************************************************
文件：DynamicWnd.cs
作者：吴炯鑫
日期：2023/3/17 16:50:58
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot 
{
    public Animation tipsAni;
    public Text txtTips;
    private bool isTipsShow = false;
    private Queue<string> tipsQueue = new Queue<string>();

    protected override void InitWnd()
    {
        base.InitWnd();
        SetActive(txtTips, false);
    }

    public void AddTips(string tips)
    {
        lock (tipsQueue)
        {
            tipsQueue.Enqueue(tips);
        }
    }

    private void Update()
    {
        if(tipsQueue.Count > 0 && isTipsShow == false)
        {
            lock (tipsQueue)
            {
                string tip = tipsQueue.Dequeue();
                SetTips(tip);
                isTipsShow = true;
            }   
        }
    }

    private void SetTips(string tips)
    {
        SetActive(txtTips, true);
        SetText(txtTips, tips);

        AnimationClip clip = tipsAni.GetClip("TipsShowAni");
        tipsAni.Play();
        //延时关闭激活状态
        StartCoroutine(PlayAniDone(clip.length, () =>
        {
            SetActive(txtTips, false);
            isTipsShow = false;
        }));
    }

    private IEnumerator PlayAniDone(float sec, Action action)
    {
        yield return new WaitForSeconds(sec);
        if(action != null)
        {
            action();
        }
    }
}