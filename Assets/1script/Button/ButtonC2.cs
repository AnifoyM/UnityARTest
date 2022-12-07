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
        Application.Quit();//����ϵͳ�˳��ӿ�
    }

    public void move_scene(int id)
    {
        SceneManager.LoadScene(id);//����id���ݣ�����unity����
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
        }//���ö�����������        
    }

    public void showversion()
    {
        version.gameObject.SetActive(true);//ʹversion����Ļ״̬��Ϊ1
    }
    
}
