using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class RocketSky : MonoBehaviour
{
    private float _yStart;

    private void Start()
    {
        _yStart = transform.position.y;
    }

    [YarnCommand("move")]
    public void MoveCharacter(string destinationName) {
       print(destinationName);
        int currentDelta = int.Parse(destinationName);
       transform.DOMoveY(_yStart - currentDelta, 5).SetEase(Ease.InOutCubic);

        float pos = currentDelta / Mathf.Abs(_yStart * 2);
        GameObject.Find("Rocket").GetComponentInChildren<RocketColor>().TweenToPos(pos);
        GameObject.Find("Rocket2").GetComponentInChildren<RocketColor>().TweenToPos(pos);
    }
}
