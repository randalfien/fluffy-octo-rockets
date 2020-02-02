using DG.Tweening;
using UnityEngine;

public class CloudAnim : MonoBehaviour
{
    public Vector3 Target = new Vector3(-49,-42,-13);
    public float Time = 1.8f;
    void Start()
    {
        transform.DOLocalMove(Target, Time).OnComplete(DestroyAfter);
    }
    
    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}
