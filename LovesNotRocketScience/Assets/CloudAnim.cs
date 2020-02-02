using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloudAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOLocalMove(new Vector3(-49, -42, -13), 1.8f).OnComplete(DestroyAfter);
    }

    // Update is called once per frame
    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}
