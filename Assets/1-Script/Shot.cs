using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

   
/// <summary>
/// 截图保存安卓手机相册
/// </summary>
public class Shot : MonoBehaviour
{
    private string filename;
    private int hour;
    private int minute;
    private int second;
    private int year;
    private int month;
    private int day;
    //截图按钮点击事件
    private void Update()
    {
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;
        filename = string.Format("{3:D4}{4:D2}{5:D2}"+"{0:D2}{1:D2}{2:D2}", hour, minute, second, year, month, day);
    }
    public void ScreenShootOnClick()
    {
        ScreenCapture.CaptureScreenshot("Scrshot" + filename+".png", 0);
        Debug.Log(filename);
    }
}