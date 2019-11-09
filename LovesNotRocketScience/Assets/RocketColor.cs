
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
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = Clr;

        mesh.colors = colors;
    }

    public void TweenToPos(float pos)
    {
        _targetPos = pos;
    }
    
    void Update()
    {
        if (_pos < _targetPos)
        {
            _pos += Time.deltaTime;
            Clr = Gradient.Evaluate(_pos);
            UpdateColor();
        }
    }
}
