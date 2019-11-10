using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubble : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro TextField;

    public string Text
    {
        set { TextField.text = value; }
    }
    
    public TextMeshPro TextText
    {
        get { return TextField; }
    }
}
