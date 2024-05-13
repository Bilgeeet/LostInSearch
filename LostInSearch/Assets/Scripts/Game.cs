using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Game : MonoBehaviour
{
    public static Game singleton;
    public static float Delta, PhysicsDelta;
    void Awake()
    {
        singleton = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        Delta = Time.deltaTime;
    }
    void FixedUpdate()
    {
        PhysicsDelta = Time.fixedDeltaTime;
    }
}
