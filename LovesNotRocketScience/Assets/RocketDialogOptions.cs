using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketDialogOptions : MonoBehaviour
{
    public TextMeshPro Text1;
    public TextMeshPro Text2;
    public GameObject Arrow1;
    public GameObject Arrow2;

    public void SetOptions(IList<string> options)
    {
        if (options.Count < 2) return;

        Text1.text = options[0];
        Text2.text = options[1];
        Arrow1.SetActive(true);
        Arrow2.SetActive(false);
    }
}
