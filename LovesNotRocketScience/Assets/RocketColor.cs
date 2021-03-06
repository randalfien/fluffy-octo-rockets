﻿
using UnityEngine;

public class RocketColor : MonoBehaviour
{
    public Gradient Gradient;
    
    public Color Clr;

    private float _pos;
    private float _targetPos;
    

    void Start()
    {
        Clr = Gradient.Evaluate(0);
        UpdateColor();
    }

    private void UpdateColor()
    {
        var mesh = GetComponent<SpriteRenderer>();
        mesh.color = Clr;
        RocketDialogUI.TextColor = Clr;
    }

    public void TweenToPos(float pos)
    {
        if (pos < _targetPos)
        {
            pos = 1 - pos;
        }
        _targetPos = pos;
        Debug.Log("target pos:" + pos);
    }
    
    void Update()
    {
        if (_pos < _targetPos)
        {
            _pos += Time.deltaTime/100f;
            Clr = Gradient.Evaluate(_pos);
        }
        
        UpdateColor(); // move this into the if 
    }
}
