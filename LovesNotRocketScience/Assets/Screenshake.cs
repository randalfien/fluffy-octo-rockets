using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    public float Strength = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Camera1.DOShakePosition(145f, Vector3.one * Strength, 15, 90F, false);
        Camera2.DOShakePosition(145f, Vector3.one * Strength, 15, 90F, false);
    }
}
