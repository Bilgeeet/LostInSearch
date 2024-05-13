using System;
using SojaExiles;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Transform TR;
    public Movement movement;
    public Cmd cmd;
    public ThirdPersonCamera thirdPersonCam;

    public Transform model;

    void Start()
    {
        TR = transform;

        cmd.Init(this);
        movement.Init(this);
        thirdPersonCam.Init(this);
    }
    void Update()
    {
        movement.HandleInput();
        thirdPersonCam.HandleInput();
        thirdPersonCam.Update();
    }
    void FixedUpdate()
    {
        movement.PhysicsUpdate();
    }


}
