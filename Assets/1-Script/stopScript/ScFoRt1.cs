using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScFoRt1 : MonoBehaviour
{
    public GameObject cont;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x <= 0.4 && transform.localPosition.x >= -0.4 && transform.localPosition.y <= 3.5 && transform.localPosition.y >= 2.7)
        {
            transform.localPosition = new Vector3(0f, 3.104f, 0);
            cont.GetComponent<rocketre>().rt1 = 1;
        }//预设火箭存放位置，如果火箭到达位置附近 则重新设定火箭位置
        else cont.GetComponent<rocketre>().rt1 = 0;
    }
}
