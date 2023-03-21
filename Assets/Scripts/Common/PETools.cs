/****************************************************
    文件：PETools.cs
	作者：吴炯鑫
    日期：2023/3/21 16:21:11
	功能：工具类
*****************************************************/
using System;

public class PETools 
{
    public static int RDInt(int min, int max, Random rd = null)
    {
        if(rd == null) rd = new Random();
        int val = rd.Next(min, max + 1);
        return val;
    }
}