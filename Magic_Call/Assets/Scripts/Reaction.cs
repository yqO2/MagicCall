using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    GameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        LineRenderer lr = this.GetComponentInChildren<LineRenderer>();

        //Destroy(other);
        if (gm.isSame)
        {
            if (lr.startColor == other.GetComponent<ElementData>().color)
            {
                Destroy(other.gameObject);
                gm.e--;
                gm.AddScore(1);
            }
            return;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("11");
        if (gm.isSame) return;

        LineRenderer lr = this.GetComponentInChildren<LineRenderer>();
        Color t=other.GetComponent<ElementData>().color;
        lr.startColor =t;// 
        lr.endColor = t;
       // 
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("11");
        LineRenderer lr = this.GetComponentInChildren<LineRenderer>();
       
        //Destroy(other);
        if (gm.isSame)
        {
            if (lr.startColor == other.GetComponent<ElementData>().color)
            {
                Destroy(other.gameObject);
                gm.e--;
                gm.AddScore (1);
            }
            return;
        }

        lr.startColor = Color.white;
        lr.endColor = Color.white;
    }

}
