/****************************************************
文件：AudioSvc.cs
作者：吴炯鑫
日期：2023/3/17 15:19:48
功能：声音播放服务
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoBehaviour 
{
    public static AudioSvc Instance = null;
    public AudioSource bgAudio;
    public AudioSource uiAudio;

    public void InitSvc()
    {
        Instance= this;
        PECommon.Log("Init AudioSvc...");
    }

    public void PlayBGAudio(string name, bool isLoop = true)
    {
        AudioClip audioClip = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if(bgAudio.clip == null || bgAudio.clip.name != audioClip.name)
        {
            bgAudio.clip= audioClip;
            bgAudio.loop= isLoop;
            bgAudio.Play();
        }    
    }

    public void PlayUIAudio(string name)
    {
        AudioClip audioClip = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        uiAudio.clip= audioClip;
        uiAudio.Play();
    }
}