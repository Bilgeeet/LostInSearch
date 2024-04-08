using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PolaroidMove : MonoBehaviour
{

    public GameObject canvasObjects;
    public float CanvasPosition = -3.5f;
    public float spentTime = 1f;

    public SceneTransition sceneTransition;


    // Start is called before the first frame update
    void Start()
    {
        Move();
        sceneTransition.OnComplete();
    }

    void Update()
    {
        
    }

     private void Move()
    {
        canvasObjects.transform.DOMoveX(CanvasPosition, spentTime);
        Debug.Log("working");
    }
}
