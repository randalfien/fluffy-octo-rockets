using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoonScript : MonoBehaviour
{

    public SpriteRenderer Sprite;

    public float TimeMoveY = 25f;
    public float DelayX = 6f;
    public float TimeFadeIn = 3f;
    public float DelayFade= 2f;
    void Start()
    {
        Sprite.color = new Color(1,1,1,0);
        Sprite.DOFade(0.82f, TimeFadeIn).SetDelay(DelayFade).SetEase(Ease.InOutCubic);
        
        transform.DOLocalMoveX(-16f, TimeMoveY-DelayX).SetDelay(DelayX+DelayFade).SetEase(Ease.InExpo );
        transform.DOLocalMoveY(8f, TimeMoveY).SetDelay(DelayFade).SetEase(Ease.InQuad);
    }
}
