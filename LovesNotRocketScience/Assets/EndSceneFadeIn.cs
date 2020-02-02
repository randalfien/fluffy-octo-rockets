 using System.Collections;
 using System.Collections.Generic;
 using DG.Tweening;
 using UnityEngine;
 using UnityEngine.SceneManagement;
using Yarn.Unity;

public class EndSceneFadeIn : MonoBehaviour
{

    public SpriteRenderer sprite;

    void Start()
    {
        StartCoroutine("Flash");
    }

    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.42f);
        sprite.DOFade(0.7f, 0.5f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.42f);
        sprite.DOKill();
        sprite.color = Color.white;
        sprite.DOFade(0f, 1.2f).SetEase(Ease.InCubic);
    }

}