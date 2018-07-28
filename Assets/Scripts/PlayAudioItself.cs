using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayAudioItself : MonoBehaviour {

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {GetComponent<AudioSource>().Play() ; });
    }
}
