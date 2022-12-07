using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttoncontrol : MonoBehaviour
    //这是按钮控制脚本 用于控制按钮的不同功能
{
    public GameObject m_object;
    public GameObject button2;
    public GameObject fashejia;
    public GameObject firebutton;
    public Text text1;
    public AudioClip audio_3;
    int a = 0;
    // Start is called before the first frame update
    public void firerocket()
    {
        if (a == 1)
        {
            GameObject.Find("rocket_01").GetComponent<Animator>().SetTrigger("button");
            GameObject.Find("launch01").GetComponent<Animator>().SetTrigger("button");
            text1.text = "单指旋转火箭 双指放大缩小";
            Destroy(firebutton);
            //触发后更新火箭动画机，使火箭的动画进行下一步
        }
    }

    public void refire()
    {
        GameObject.Find("rocket_01").GetComponent<Animator>().SetTrigger("button2");
        GameObject.Find("launch01").GetComponent<Animator>().SetTrigger("abutton");
        GameObject.Find("allcube").GetComponent<Animator>().SetTrigger("botton");
        text1.text = "单指旋转火箭 双指放大缩小";
        //触发后更新火箭动画机2，使火箭的动画进行下一步
    }

    public void setbutton()
    {
        GameObject.Find("launch01").GetComponent<Animator>().SetTrigger("abutton");
        GameObject.Find("rocket_01").GetComponent<Animator>().SetTrigger("button2");     
        GameObject.Find("allcube").GetComponent<Animator>().SetTrigger("botton");
        Destroy(button2);
        a = 1;
        Invoke("Desandtext", 1f);
        AudioSource.PlayClipAtPoint(audio_3, new Vector3(-63.6f, 12, -736f));
        //声音播放控件
    }
    public void exitgame()
    {
        SceneManager.LoadScene(1);
    }
    public void AClick()
    {
        SceneManager.LoadScene(2);//level2为我们要切换到的场景
    }
    void Desandtext()
    {
        Destroy(m_object);
        Destroy(fashejia);
        text1.text = "点击右边按钮以发射火箭→";
        //销毁预制件
    }
}
