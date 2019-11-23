using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float Time = 5f;
    public float Delay = 1f;
    void Awake()
    {
        transform.position = new Vector3(5.13f, 0, transform.position.z);
        var origSize = GetComponent<Camera>().orthographicSize;
        GetComponent<Camera>().orthographicSize = 3.84f;

        GetComponent<Camera>().DOOrthoSize(origSize, Time).SetDelay(Delay).SetEase(Ease.InOutQuad);
        transform.DOMoveX(0, Time).SetDelay(Delay).SetEase(Ease.InOutQuad);
    }
}
