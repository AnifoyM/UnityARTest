using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonC2 : MonoBehaviour
{
    //public int sceneid;
    public GameObject buttondisplay;
    int buttonjob = 0;
    public GameObject version;
    public Animator ani_main;
    // Start is called before the first frame update
    public void quit()
    {
        Application.Quit();//调用系统退出接口
    }

    public void move_scene(int id)
    {
        SceneManager.LoadScene(id);//根据id数据，更换unity场景
    }

    public void displaybutton()
    {
        if (buttonjob == 0) {
            buttondisplay.SetActive(true);
            ani_main.SetBool("button", true);
            buttonjob = 1;
        }
        else
        {
            ani_main.SetBool("button", false);
            buttondisplay.SetActive(false);
            buttonjob = 0;
        }//设置动画机的运行        
    }

    public void showversion()
    {
        version.gameObject.SetActive(true);//使version物体的活动状态设为1
    }
    
}
