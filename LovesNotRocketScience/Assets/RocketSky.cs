using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class RocketSky : MonoBehaviour
{
    private float _yStart;
    private int _currentDelta;
    private void Start()
    {
        _yStart = transform.position.y;

    }

    [YarnCommand("move")]
    public void MoveCharacter(string destinationName) {
       print(destinationName);
        _currentDelta = int.Parse(destinationName);
       transform.DOMoveY(_yStart - _currentDelta, 5).SetEase(Ease.InOutCubic);

        float pos = _currentDelta / Mathf.Abs(_yStart * 2);
        GameObject.Find("Rocket1").GetComponentInChildren<RocketColor>().TweenToPos(pos);
        GameObject.Find("Rocket2").GetComponentInChildren<RocketColor>().TweenToPos(pos);
    }


}
