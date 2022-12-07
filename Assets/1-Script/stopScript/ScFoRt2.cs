using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScFoRt2 : MonoBehaviour
{
    public GameObject cont;
    // Start is called before the first frame update

    void Update()
    {
        if (transform.localPosition.x <= 0.4 && transform.localPosition.x >= -0.4 && transform.localPosition.y <= 2 && transform.localPosition.y >= 1.2)
        {
            transform.localPosition = new Vector3(0f, 1.59f, 0);
            cont.GetComponent<rocketre>().rt2 = 1;
        }//预设火箭存放位置，如果火箭到达位置附近 则重新设定火箭位置
        else cont.GetComponent<rocketre>().rt2 = 0;
    }
}
