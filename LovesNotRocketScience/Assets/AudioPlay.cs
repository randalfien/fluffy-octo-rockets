using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        Invoke("PlaySource",13f);
    }

    void PlaySource() {
        source.enabled = !source.enabled;
    }
}
