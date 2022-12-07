using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MainControl : MonoBehaviour
{
    public int Rate = 60;
    private void Start()
    {
        Application.targetFrameRate = Rate;
    }//将进程的帧率限制为60FPS

}