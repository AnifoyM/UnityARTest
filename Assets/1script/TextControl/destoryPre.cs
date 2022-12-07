using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryPre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject button = GameObject.Find("Canvas/Desbutton");
        if (button.GetComponent<ButtonControl>().a == 1)
        {
            button.GetComponent<ButtonControl>().a = 0;
            Destroy(this);
        }
    }
}
