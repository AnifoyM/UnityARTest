using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startchange : MonoBehaviour
{

    // Use this for initialization

    public void AClick()
    {
        SceneManager.LoadScene(1);//level1为我们要切换到的场景
    }

}
