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
    
    private void Awake()
    {
        _posLeftStart = RocketLeft.position;
        _posRightStart = RocketRight.position;
    }

    [YarnCommand("setvalue")]
    public void SetAffection(string param)
    {
        Debug.Log("setting affection to " + param);
        int dist = int.Parse(param)-4;
        var targetLeftR = new Vector3(_posLeftStart.x + dist*speed,  _posLeftStart.y, _posLeftStart.z);
        RocketLeft.DOMove(targetLeftR, 5f).SetEase(Ease.InOutBack);

        var targetRightR = _posRightStart.x - dist * speed;
        var movementt = RocketRight.GetComponent<RocketMovement>();
        
        DOTween.To(()=> movementt.TargetX, x=> movementt.TargetX = x, targetRightR, 5f).SetDelay(1).SetEase(Ease.InOutBack);
    }
}
