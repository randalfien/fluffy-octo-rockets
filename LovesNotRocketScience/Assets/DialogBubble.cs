using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubble : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro TextField;

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
        TextField.text = "";
        foreach (char c in _text) 
        {
            TextField.text += c;
            yield return null;
        }
    }
    
    public TextMeshPro TextText
    {
        get { return TextField; }
    }
}
