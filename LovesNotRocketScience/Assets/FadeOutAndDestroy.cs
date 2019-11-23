using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeOutAndDestroy : MonoBehaviour
{
    public float Time = 4f;

    public float Delay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().DOFade(0, Time).SetDelay(Delay).SetEase(Ease.InOutCubic).OnComplete(DestroyThisObject);
    }

    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
