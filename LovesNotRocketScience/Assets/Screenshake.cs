using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    public float Strength = 1f;

    public bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        if (isStart)
        {
            Camera1.DOShakePosition(11f, Vector3.one * Strength, 35, 90F);
            Camera2.DOShakePosition(11f, Vector3.one * Strength, 35, 90F);
        }
        else
        {
            Camera1.DOShakePosition(145f, Vector3.one * Strength, 20, 90F, false);
            Camera2.DOShakePosition(145f, Vector3.one * Strength, 20, 90F, false);
        }
    }
}
