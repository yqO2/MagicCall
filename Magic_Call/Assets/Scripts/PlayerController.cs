using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool isBack = true;
    public bool isTurning = false;
    //public bool isInTurning = false;
    public GameObject inner;

    bool isFirst = true;
    int floorMask;
    Vector3 t;

    GameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        floorMask = LayerMask.GetMask("Floor");
    }
    private void Update()
    {
        if (isTurning==false&&Input.GetMouseButtonDown(0)) { isBack = false;isTurning = true; }
        if ((gm.isSame)||Input.GetMouseButtonUp(0))
        {
            isBack = true;
            isFirst = true;
        }

        if (isBack) TraceBack();
        else
        {
            Turning();
        }
    }
    
    void Turning()//转动外盘或者内盘
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if(Physics .Raycast (camRay ,out floorHit ,10f,floorMask))
        {
            float  x = floorHit.point.x;
            float y = floorHit.point.y;
            //Debug.Log(floorHit .point .ToString());
            if (isFirst) { t = floorHit.point; isFirst = false; }
            Quaternion newRotation = Quaternion.FromToRotation(t,floorHit.point);

            //Debug.Log(newRotation.ToString());
                transform.rotation = newRotation;

        }
    }
    

    void TraceBack()//w外盘回滚
    {
        Vector3 euler = this.transform.rotation.eulerAngles;
        //Debug.Log(euler.ToString());
        if (euler.z > 2&&euler.z<180)
        {
            euler.z -= speed;
        }
        else if (euler.z >=180)
        {
            euler.z += speed;
        }
        else
        {
            isTurning = false;
           // isInTurning = false;
        }
        this.transform.rotation = Quaternion.Euler(euler);
    }
}
