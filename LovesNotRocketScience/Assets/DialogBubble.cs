using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogBubble : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro TextField;

    public AudioSource Audio;

    public AudioClip[] R1Sounds;
    public AudioClip[] R2Sounds;

    public int Type; // 1 or 2
    
    private string _text;
    public string Text
    {
        set
        {
            _text = value;
            StartCoroutine(PlayText());
        }
    }
    
    IEnumerator PlayText()
    {
        Audio.volume = 0.35f;
        Audio.clip = GetAudioClip();
        Audio.Play();
        TextField.text = "";
        foreach (char c in _text) 
        {
            TextField.text += c;
            yield return null;
        }

        Audio.DOFade(0,0.3f);
    }

    private AudioClip GetAudioClip()
    {
        if (Type == 1)
        {
            var i = Random.Range(0, R1Sounds.Length - 1);
            return R1Sounds[i];
        }
        var j = Random.Range(0, R2Sounds.Length - 1);
        return R2Sounds[j];
    }

    public TextMeshPro TextText
    {
        get { return TextField; }
    }
}
