using System;
using SojaExiles;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Transform TR;
    public Movement movement;
    public ThirdPersonCamera thirdPersonCam;

    private void Start()
    {
        TR = transform;
        movement.Init(this);
        thirdPersonCam.Init(this);
    }
    private void Update()
    {
        
        thirdPersonCam.Update();
    }
}