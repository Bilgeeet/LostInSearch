using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ThirdPersonCamera
{
    [HideInInspector] public Player player;
    public Transform cameraTR;
    public Vector3 offset = Vector3.zero;

    public float cam_distance = 2f;

    public Vector2 rot;
    public Vector2 sens = Vector2.one;

    public void Init(Player player)
    {
        this.player = player;
    }
    public void Update()
    {


        /* Camera rotation stuff, mouse controls this shit */
        rot.x += Input.GetAxisRaw("Mouse X") * sens.x * 0.2f;
        rot.y -= Input.GetAxisRaw("Mouse Y") * sens.y * 0.2f;

        if (Mathf.Abs(rot.y) > 89.5f)
            rot.y = Mathf.Sign(rot.y) * 89.5f;

        if (Mathf.Abs(rot.x) >= 360f)
            rot.x = 0f;

        Vector3 cam_start_pos = player.TR.position + offset;
        Vector3 look_direction = Utilities.DegreesToDirection(in rot.x, in rot.y);
        if (Physics.Raycast(cam_start_pos, -look_direction, out RaycastHit hitInfo, cam_distance, ~64)) // all layers except for Player, which is 2^6
        {
            cameraTR.position = hitInfo.point + 0.01f * look_direction;
            Debug.Log(hitInfo.collider.name);
        }
        else
        {
            cameraTR.position = cam_start_pos - look_direction * cam_distance;
        }
        cameraTR.eulerAngles = new Vector3(rot.y, rot.x, 0f);
    }

}