using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starttxt : MonoBehaviour
{
    public TextAsset 版本文档;
    // Start is called before the first frame update
    void Start()
    {
        Text 版本更新;
        版本更新 = this.transform.GetComponent<Text>();
        版本更新.text = 版本文档.text;
    }//将文本内容设置为预存的txt文件的内容

    // Update is called once per frame
    void Update()
    {
        
    }
}
