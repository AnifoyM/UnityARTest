using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starttxt : MonoBehaviour
{
    public TextAsset �汾�ĵ�;
    // Start is called before the first frame update
    void Start()
    {
        Text �汾����;
        �汾���� = this.transform.GetComponent<Text>();
        �汾����.text = �汾�ĵ�.text;
    }//���ı���������ΪԤ���txt�ļ�������

    // Update is called once per frame
    void Update()
    {
        
    }
}
