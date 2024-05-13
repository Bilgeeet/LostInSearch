using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class ThirdPersonCamera
{
    [HideInInspector] public Player player;
    public Transform cameraTR;
    public Vector3 offset = Vector3.zero;

    public float cam_distance = 2f;

    public Vector2 Rot;
    public Vector2 sens = Vector2.one;

    public void Init(Player player)
    {
        this.player = player;
    }
    public void HandleInput()
    {
        /* Camera rotation stuff, mouse controls this shit */
        Rot.x += Input.GetAxisRaw("Mouse X") * sens.x * 0.2f;
        Rot.y -= Input.GetAxisRaw("Mouse Y") * sens.y * 0.2f;

        if (Mathf.Abs(Rot.y) > 89.5f)
            Rot.y = Mathf.Sign(Rot.y) * 89.5f;

        if (Mathf.Abs(Rot.x) >= 360f)
            Rot.x = 0f;
    }
    public void Update()
    {

        Vector3 cam_start_pos = player.TR.position + offset;
        Vector3 look_direction = Utilities.DegreesToDirection(in Rot.x, in Rot.y);
        if (Physics.Raycast(cam_start_pos, -look_direction, out RaycastHit hitInfo, cam_distance, ~64)) // all layers except for Player, which is 2^6
        {
            cameraTR.position = hitInfo.point + 0.01f * look_direction;
            // Debug.Log(hitInfo.collider.name);
        }
        else
        {
            cameraTR.position = cam_start_pos - look_direction * cam_distance;
        }
        cameraTR.eulerAngles = new Vector3(Rot.y, Rot.x, 0f);
        player.model.eulerAngles = new Vector3(0f, Rot.x, 0f);
    }

}