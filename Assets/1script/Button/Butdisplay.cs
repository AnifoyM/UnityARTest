using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butdisplay : MonoBehaviour
{
    public GameObject others;
    // Start is called before the first frame update
    void Start()
    {
        others.SetActive(false);//将设置的others物体设为不活动
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
