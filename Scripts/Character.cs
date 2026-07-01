using Godot;
using System;

public partial class Character : CharacterBody2D
{
    public override void _PhysicsProcess(double delta)
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        inputDirection = inputDirection * 20;

        Velocity = inputDirection;

        MoveAndSlide();
    }
}
