using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketColor : MonoBehaviour
{
    public MeshFilter filter;

    public Color Clr;
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        // create new colors array where the colors will be created.
        Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            colors[i] = Clr;

        // assign the array of colors to the Mesh.
        mesh.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        Start();
    }
}
