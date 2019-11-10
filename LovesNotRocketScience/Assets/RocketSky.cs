using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class RocketSky : MonoBehaviour
{
    private float _yStart;
    private int currentDelta;
    private float moonDelta;
    private float MoonStart;
    private void Start()
    {
        _yStart = transform.position.y;
        MoonStart = (_yStart-26.6f);
        
    }

    [YarnCommand("move")]
    public void MoveCharacter(string destinationName) {
       print(destinationName);
        currentDelta = int.Parse(destinationName);
       transform.DOMoveY(_yStart - currentDelta, 5).SetEase(Ease.InOutCubic);

        float pos = currentDelta / Mathf.Abs(_yStart * 2);
        GameObject.Find("Rocket1").GetComponentInChildren<RocketColor>().TweenToPos(pos);
        GameObject.Find("Rocket2").GetComponentInChildren<RocketColor>().TweenToPos(pos);

        MoveMoon();

    }

    public void MoveMoon () {
        moonDelta = currentDelta;
        moonDelta = moonDelta/20;
        Debug.Log(moonDelta);
        GameObject.Find("Moon").GetComponent<Transform>().DOMoveY(MoonStart  - moonDelta, 5).SetEase(Ease.InOutCubic);
    }
}
