using System;
using UnityEngine;

[Serializable]
// Contains the command the user wishes upon the character
public struct Cmd
{
    [HideInInspector] public Player player;
    public Vector2 move;

    public void Init(Player player)
    {
        this.player = player;
    }

    public static readonly string
    str_MouseX = "Mouse X",
    str_MouseY = "Mouse Y",
    str_Vertical = "Vertical",
    str_Horizontal = "Horizontal";
}