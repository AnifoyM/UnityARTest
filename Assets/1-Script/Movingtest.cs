using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingtest : MonoBehaviour
{
    public float earthmovingstep;
    int t = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(earthmovingstep >0 && t == 0)
        {
            Debug.Log("out over!");
            GameObject.Find("myearth").SendMessage("earthopen",earthmovingstep);
            if(earthmovingstep == 100)t = 1;
        }
    }
}
