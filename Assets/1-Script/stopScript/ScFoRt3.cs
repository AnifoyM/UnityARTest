using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScFoRt3 : MonoBehaviour
{
    public GameObject cont;
    void Update()
    {
        if (transform.localPosition.x <= 0.4 && transform.localPosition.x >= -0.4 && transform.localPosition.y <= 1 && transform.localPosition.y >= 0.2)
        {
            transform.localPosition = new Vector3(0.047f, 0.584f, 0);
            cont.GetComponent<rocketre>().rt3 = 1;
        }//预设火箭存放位置，如果火箭到达位置附近 则重新设定火箭位置
        else { cont.GetComponent<rocketre>().rt3 = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        }
    }
}
