using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject image;
    public AudioClip audio_1;
    public void SceneInit()
    {
        Destroy(image);
        AudioSource.PlayClipAtPoint(audio_1, new Vector3(-63.6f, 12, -736f));
    }


}
