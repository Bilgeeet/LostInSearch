using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementData", menuName = "ScriptableObjects/MovementData")]
public sealed class MovementData : ScriptableObject
{
    public float
    base_move_speed = 5f,
    base_accel = 10f,
    base_air_accel = 0.3f,
    gravity = 38f,
    base_deaccel = 3f,
    base_friction = 3.5f;
}
