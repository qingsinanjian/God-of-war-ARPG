/****************************************************
    文件：MainCitySys.cs
	作者：吴炯鑫
    日期：2023/3/29 0:29:43
	功能：主城业务系统
*****************************************************/

using UnityEngine;

public class MainCitySys : SystemRoot 
{
    public static MainCitySys Instance;

    public MainCityWnd mainCityWnd;

    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
        PECommon.Log("Init MainCitySys...");
    }

    public void EnterMainCity()
    {
        resSvc.LoadSceneAsync(Constants.SceneMainCity, () =>
        {
            //TODO 加载游戏主角

            //打开主城场景UI
            mainCityWnd.SetWndState();

            //播放主城背景音乐
            audioSvc.PlayBGAudio(Constants.BGMainCity);

            //设置人物展示相机
        });
    }
}