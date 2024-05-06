using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public const float DegToRad = 0.01745329251994329576923690768489f;
    public const float RadToDeg = 57.295779513082320876798154814105f;
    public static Vector3 DegreesToDirection(in float horizontal_degree, in float vertical_degree)
    {
        // Convert angles to radians
        float angleX = horizontal_degree * DegToRad;
        float angleY = vertical_degree * DegToRad;
        float cos_ver = Mathf.Cos(angleY);

        return new Vector3(
        Mathf.Sin(angleX) * cos_ver,
        -Mathf.Sin(angleY),
        Mathf.Cos(angleX) * cos_ver
        ).normalized;

    }
}