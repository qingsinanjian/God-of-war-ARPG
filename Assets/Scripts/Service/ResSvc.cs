/****************************************************
文件：ResSvc.cs
作者：吴炯鑫
日期：2023/3/16 19:33:21
功能：资源加载服务
*****************************************************/

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour 
{
    public static ResSvc Instance = null;
    public void InitSvc()
    {
        Instance= this;
        InitRDNameCfg();
        PECommon.Log("Init ResSvc...");
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

    private Dictionary<string, AudioClip> adDic= new Dictionary<string, AudioClip>();
    public AudioClip LoadAudio(string path, bool isCache = false)
    {
        AudioClip audioClip = null;
        if(!adDic.TryGetValue(path, out audioClip))
        {
            audioClip = Resources.Load<AudioClip>(path);
            if(isCache)
            {
                adDic.Add(path, audioClip);
            }
        }
        return audioClip;
    }

    #region InitCfgs
    private List<string> surnameLst = new List<string>();
    private List<string> manLst = new List<string>();
    private List<string> womanLst = new List<string>();
    private void InitRDNameCfg()
    {
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.RDNameCfg);
        if (!xml)
        {
            PECommon.Log("xml file:" + PathDefine.RDNameCfg + "not exist");
        }
        else
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.text);
            //获取根节点下的所有子节点的List
            XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;
            //将某一个节点转化为一个XmlElement
            for (int i = 0; i < nodLst.Count; i++)
            {
                XmlElement ele = nodLst[i] as XmlElement;
                if (ele.GetAttributeNode("ID") == null) continue;
                int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
                foreach (XmlElement item in nodLst[i].ChildNodes)
                {
                    switch (item.Name)
                    {
                        case "surname":
                            surnameLst.Add(item.InnerText);
                            break;
                        case "man":
                            manLst.Add(item.InnerText);
                            break;
                        case "woman":
                            womanLst.Add(item.InnerText);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    public string GetRDNameData(bool man = true)
    {
        string rdName = surnameLst[PETools.RDInt(0, surnameLst.Count - 1)];
        if(man)
        {
            rdName += manLst[PETools.RDInt(0, manLst.Count - 1)];
        }
        else
        {
            rdName += womanLst[PETools.RDInt(0, womanLst.Count - 1)];
        }
        return rdName;
    }
    #endregion
}