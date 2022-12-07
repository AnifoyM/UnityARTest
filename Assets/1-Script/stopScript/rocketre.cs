using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketre : MonoBehaviour
{
    public int rt1 = 0;
    public int rt2 = 0;
    public int rt3 = 0;
    int trigger = 1;
    public AudioClip Audio_2;
    
    public GameObject button;
    // Update is called once per frame
    void Update()
    {
        if(rt1 == 1 && rt2 == 1 && rt3 == 1 && trigger == 1)//如果所有火箭都到达了预定位置 则进行下一步
        {
            //GameObject.Find("rocket_01").GetComponent<Animator>().SetTrigger("button2");
            //GameObject.Find("launch01").GetComponent<Animator>().SetTrigger("abutton");
            //GameObject.Find("allcube").GetComponent<Animator>().SetTrigger("botton");
            //Destroy(m_object);
            Invoke("Nextthegame", 1f);
            trigger = 0;
            AudioSource.PlayClipAtPoint(Audio_2, new Vector3(-63.6f, 12, -736));
        }
    }

    void Nextthegame()
    {
        this.GetComponent<Selectobject>().Touchstate = 0;
        //float time = GameObject.Find("maincontrolforscript").GetComponent<MainControl>().usingstep;
        //GameObject.Find("rocket_01").GetComponent<Animator>().SetTrigger("button2");
        //GameObject.Find("launch01").GetComponent<Animator>().SetTrigger("abutton");
        //GameObject.Find("allcube").GetComponent<Animator>().SetTrigger("botton");
        //Destroy(m_object);
        button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40, -24);
    }
}
