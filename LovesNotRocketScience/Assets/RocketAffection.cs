using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class RocketAffection : MonoBehaviour
{
    public Transform RocketLeft;
    public Transform RocketRight;

    private Vector3 _posLeftStart;
    private Vector3 _posRightStart;

    public float speed = 0.05f;
    
    private void Start()
    {
        _posLeftStart = RocketLeft.position;
        _posRightStart = RocketRight.position;
    }

    [YarnCommand("setvalue")]
    public void SetAffection(string param)
    {
        int dist = int.Parse(param);
        RocketLeft.DOMove(_posLeftStart + dist*Vector3.right * speed, 5f).SetEase(Ease.InOutExpo);
        RocketRight.DOMove(_posRightStart + dist*Vector3.left * speed, 5f).SetEase(Ease.InOutExpo);
    }
}
