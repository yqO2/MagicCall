using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] edges;
    public GameObject[] elements;
    public Transform[] spwanPoints;
    public int maxE;
    public int e;
    public Text playerScore;

    int score;
    int delay;
    int i;
    GameObject curEdge;
    public bool isSame;
    Color curColor;
    PlayerController pc;

    private void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
        curColor = Color.white;
        isSame = false;
        e = 0;
        delay = 0;
        score = 0;
        i= 0;
    }
    private void FixedUpdate()
    {
        delay++;
        
    }
    private void Update()
    {
        
        if(pc.isTurning)Test();
        if (!pc.isTurning &&e < maxE)
        {
            isSame = false;
            SpawnElement();
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void AddScore(int x)
    {
        score += x;
        playerScore.text = "Score:" + score;
    }

    void SpawnElement()
    {
        if (delay > 10)
        { 
            e++;
            delay = 0;
            //Debug.Log(i);
            i = (++i) % 2;
            Instantiate(elements[Random.Range(0, elements.Length)], spwanPoints[i]);
         }
    }
    void Test()
    {
        isSame = true;
        if (edges.Length <= 1) Debug.Log("error");
        Color newColor;
        curEdge = edges[0];
        curColor = curEdge.GetComponentInChildren<LineRenderer>().startColor;

        if (curColor == Color.white)
        {
            isSame = false;
            return;
        }

        for (int i = 1; i < edges.Length; i++)
        {
            newColor = edges[i].GetComponentInChildren<LineRenderer>().startColor;
            if (newColor != curColor)
            {
                isSame = false;
                break;
            }
        }
    }
}
