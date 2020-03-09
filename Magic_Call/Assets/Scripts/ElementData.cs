using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementData : MonoBehaviour
{
    public Color color;
    Material[] materials;

    float x ;
    float y ;
    float r ;
    public Color GetColor() { return color; }

    private void Awake()
    {
        
    }
    private void Update()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        r = x * x + y * y;
        if (r>26||r<15) this.transform.position = new Vector3(0f, 4.5f, 0f);
    }
}
