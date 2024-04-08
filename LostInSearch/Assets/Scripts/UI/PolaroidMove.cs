using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PolaroidMove : MonoBehaviour
{

    public GameObject canvasObjects;
    public float CanvasPosition = -3.5f;
    public float moveSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    void Update()
    {
        
    }

     private void Move()
    {
        canvasObjects.transform.DOMoveX(CanvasPosition, moveSpeed);
    }
}
