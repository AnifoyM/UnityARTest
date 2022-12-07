using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonControl : MonoBehaviour
{
    public int button_num;
    public GameObject textwindows;
    public Transform parent1;

    public int a = 0;
    public GameObject words;

    public GameObject 识别目标;

    public GameObject video;
    public GameObject buttonText;

    public void showtext()
    {
        GameObject.Find("按钮控制组").GetComponent<Mainbutton>().booknum = button_num;//获取物体“按钮控制组”的Mainbutton脚本中的booknum变量，存入本脚本
        Instantiate(textwindows,parent1,false);//实例化textwindows物体，不存在父物体
        识别目标.gameObject.SetActive(false);//关闭识别功能

        //Debug.Log("test word1");
    }
    public void clear()
    {
        识别目标.gameObject.SetActive(false);
        识别目标.gameObject.SetActive(true);//刷新识别状态
    }
    public void destroytext()
    {
        GameObject root = GameObject.Find("识别物体组");
        root.transform.Find("识别物体").gameObject.SetActive(true);//重新打开识别功能
        
        GameObject obj = GameObject.Find("文字底板(Clone)");
        Destroy(obj);//删除上文中实例化的textwindows物体
        
        //Debug.Log("test word2");
    }

    public void next_word()//下一页
    {
        words.GetComponent<TxtTest>().uptxt(GameObject.Find("按钮控制组").GetComponent<Mainbutton>().booknum);//向words中的TxtTest脚本中发送运行uptxt函数的请求
        Debug.Log("buttonon");
    }
    
    public void downtext()//上一页
    {
        words.GetComponent<TxtTest>().downtxt(GameObject.Find("按钮控制组").GetComponent<Mainbutton>().booknum);//向words中的TxtTest脚本中发送运行downtxt函数的请求
    }

    public void getURL()
    {
        switch (button_num)//根据button_num执行打开链接功能
        {
            case 0: 
                Application.OpenURL("http://www.hep.com.cn/");
                break;
            case 1: 
                Application.OpenURL("https://www.xduph.com/");
                break;
            case 2: 
                Application.OpenURL("http://www.sciencep.com/");
                break;
            case 3:
                Application.OpenURL("https://baike.baidu.com/item/%E5%8D%97%E6%B5%B7%E5%87%BA%E7%89%88%E5%85%AC%E5%8F%B8/10871023?fr=aladdin");
                break;
        }
    }

    public void playVideo()
    {
        if (video.GetComponent<VideoPlayer>().isPlaying == false)//控制video视频的播放
        {
            //video.SetActive(true);
            video.GetComponent<VideoPlayer>().Play();
            buttonText.GetComponent<Text>().text = "暂停";
        }
        else
        {
            //video.SetActive(false);
            video.GetComponent<VideoPlayer>().Pause();
            buttonText.GetComponent<Text>().text = "播放";
        }
    }
}
