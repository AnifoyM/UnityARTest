using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public void jump()
    {
        SceneManager.LoadScene(2);//��ת����id:2
    }
}
