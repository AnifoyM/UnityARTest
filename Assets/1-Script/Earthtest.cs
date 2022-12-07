using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthtest : MonoBehaviour
{
    public void earthopen(float x)
    {
        
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, x * 0.01f);//使地球的不透明度增加
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);//使地球的初始不透明度为0
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
