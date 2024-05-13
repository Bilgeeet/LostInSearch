using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Movement
{
    [HideInInspector] public Player player;

    public MovementData data;

    private CharacterController controller;


    public Vector3
    GlobalPosition = Vector3.zero,
    velocity = Vector3.zero,
    move_direction = Vector3.zero;

    public float
    horSpeed = 0f,
    target_speed = 0f,
    target_accel = 0f;
    public bool isGrounded;


    public void Init(Player player)
    {
        this.player = player;
        // Hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player.TryGetComponent(out controller);

        target_speed = data.base_move_speed;
        target_accel = data.base_accel;
    }
    public void HandleInput()
    {
        player.cmd.move.x = Input.GetAxisRaw(Cmd.str_Horizontal);
        player.cmd.move.y = Input.GetAxisRaw(Cmd.str_Vertical);
        CalculateDiagonalMoveDirection();
    }
    void GroundCheck()
    {
        bool grounded = controller.isGrounded;
        if (grounded == isGrounded) return;

        isGrounded = grounded;
        if (grounded)
        {
            Debug.Log("Landed");
        }
        else
        {
            Debug.Log("Lifted up");
        }
    }
    public void PhysicsUpdate()
    {
        /* Ensure that the cursor is locked into the screen */
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            if (Input.GetButtonDown("Fire1"))
                Cursor.lockState = CursorLockMode.Locked;
        }

        GroundCheck();
        /* Movement, here's the important part */

        doMove();

        // Move the controller
        controller.Move(velocity * Game.PhysicsDelta);

    }

    /*******************************************************************************************************\
   |* MOVEMENT
   \*******************************************************************************************************/


    void CalculateDiagonalMoveDirection() // more efficient than using Godot's Basis infested RotateAxis mess
    {
        // Convert Euler angles to radians
        float y = player.thirdPersonCam.Rot.x * Utilities.DegToRad; // DegToRad

        // Calculate the diagonal move direction using the Euler angles
        float cosY = Mathf.Cos(y);
        float sinY = Mathf.Sin(y);

        move_direction.x = cosY * player.cmd.move.x + sinY * player.cmd.move.y;
        move_direction.z = -sinY * player.cmd.move.x + cosY * player.cmd.move.y;


        float length = move_direction.x * move_direction.x + move_direction.z * move_direction.z;
        if (length > 0f)
        {
            length = Mathf.Sqrt(length);
            move_direction.x /= length;
            move_direction.z /= length;
        }
    }

    void doMove()
    {
        float horSpeedSquared = velocity.x * velocity.x + velocity.z * velocity.z;

        horSpeed = horSpeedSquared > 0f ? Mathf.Sqrt(horSpeedSquared) : 0f;

        // Deacceleration and Friction
        if (isGrounded)
        {
            float control = horSpeed < data.base_deaccel ? data.base_deaccel : horSpeed;
            float drop = control * data.base_friction * Game.PhysicsDelta;
            float newspeed = horSpeed - drop;

            if (newspeed < 0f)
                newspeed = 0f;
            if (horSpeed > 0f)
                newspeed /= horSpeed;

            velocity.x *= newspeed;
            velocity.z *= newspeed;
            // ground_move();
        }
        else
        {
            velocity.y -= data.gravity * Game.PhysicsDelta;
            // air_move();
        }
        // Acceleration
        float currentspeed = velocity.x * move_direction.x + velocity.z * move_direction.z; // Basically Vector2 dot product
        float addspeed = target_speed - currentspeed;
        if (addspeed <= 0f)
            return;
        float accelspeed = target_accel * Game.PhysicsDelta * target_speed;
        if (accelspeed > addspeed)
            accelspeed = addspeed;


        velocity.x += accelspeed * move_direction.x;
        velocity.z += accelspeed * move_direction.z;

    }

    void OnGUI()
    {
        var ups = controller.velocity;
        ups.y = 0;
        GUI.Label(new Rect(0, 15, 400, 100), "Speed: " + Mathf.Round(ups.magnitude * 100) / 100 + "ups");
    }
}