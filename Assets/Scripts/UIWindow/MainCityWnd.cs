/****************************************************
    文件：MainCityWnd.cs
	作者：吴炯鑫
    日期：2023/3/29 0:27:33
	功能：主城UI界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using PEProtocol;

public class MainCityWnd : WindowRoot 
{
    public Text txtFight;
    public Text txtPower;
    public Image imgPowerPrg;
    public Text txtLevel;
    public Text txtName;
    public Text txtExpPrg;

    public Transform expPrgTrans;

    protected override void InitWnd()
    {
        base.InitWnd();
        RefreshUI();
    }

    private void RefreshUI()
    {
        PlayerData pd = GameRoot.Instance.PlayerData;
        SetText(txtFight, PECommon.GetFightByProps(pd));
        SetText(txtPower, "体力:" + pd.power + "/" + PECommon.GetPowerLimit(pd.lv));
        imgPowerPrg.fillAmount = pd.power * 1.0f / PECommon.GetPowerLimit(pd.lv);
        SetText(txtLevel, pd.lv);
        SetText(txtName, pd.name);

        int expPrgVal = (int)((pd.exp * 1.0f / PECommon.GetExpUpByVal(pd.lv)) * 100);
        SetText(txtExpPrg, expPrgVal + "%");
        int index = expPrgVal / 10;

        GridLayoutGroup grid = expPrgTrans.GetComponent<GridLayoutGroup>();
        float globalScaleRate = 1.0f * Constants.ScreenStandardHeight / Screen.height;
        float uiWidth = Screen.width * globalScaleRate;
        float expSize = (uiWidth - 180) / 10;//180为所有空隙长度,共10个经验条
        grid.cellSize = new Vector2(expSize, 7);

        for (int i = 0; i < expPrgTrans.childCount; i++)
        {
            Image img = expPrgTrans.GetChild(i).GetComponent<Image>();
            if (index > i)
            {
                img.fillAmount = 1;
            }
            else if(index == i)
            {
                img.fillAmount = expPrgVal % 10 * 1.0f / 10;
            }
            else
            {
                img.fillAmount = 0;
            }
        }
    }
}