using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class RocketRotation : MonoBehaviour
{
    [YarnCommand("rotate")]
    public void Rotate(string howmuch)
    {
        float angle = (float) int.Parse(howmuch);
        transform.DOLocalRotate(new Vector3(0,0,angle), 6).SetEase(Ease.InOutQuad);
    }
}
