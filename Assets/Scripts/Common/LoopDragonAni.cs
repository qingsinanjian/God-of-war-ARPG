/****************************************************
文件：LoopDragonAni.cs
作者：吴炯鑫
日期：2023/3/17 16:24:45
功能：飞龙循环动画
*****************************************************/

using UnityEngine;

public class LoopDragonAni : MonoBehaviour 
{
    private Animation ani;

    private void Awake()
    {
        ani = GetComponent<Animation>();
    }

    private void Start()
    {
        if(ani != null)
        {
            InvokeRepeating("PlayDragonAni", 0, 20);
        }
    }

    private void PlayDragonAni()
    {
        if(ani != null)
        {
            ani.Play();
        }
    }
}