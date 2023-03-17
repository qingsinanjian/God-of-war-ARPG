/****************************************************
文件：LoadingWnd.cs
作者：吴炯鑫
日期：2023/3/16 20:29:6
功能：加载进度界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoadingWnd : WindowRoot 
{
    public Text txtTips;
    public Image imgFG;
    public Image imgPoint;
    public Text txtPre;

    private float fgWidth;

    protected override void InitWnd()
    {
        base.InitWnd();
        fgWidth = imgFG.GetComponent<RectTransform>().sizeDelta.x;
        txtTips.text = "这是一条小提示";
        imgFG.fillAmount = 0;
        imgPoint.transform.localPosition = new Vector3(-fgWidth / 2, 0);
        txtPre.text = "0%";
    }

    public void SetProgress(float progress)
    {
        txtPre.text = (int)(progress * 100) + "%";
        imgFG.fillAmount = progress;
        imgPoint.rectTransform.anchoredPosition = new Vector2(progress * fgWidth - fgWidth / 2, 0);
    }
}