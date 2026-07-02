using Godot;
using System;
using System.Numerics;

public partial class Character : CharacterBody2D
{

    public float speed = 300.0f;
    public float jumpspeed = -400.0f;
    public override void _PhysicsProcess(double delta)
    {
        Godot.Vector2 velocity = Velocity;

        velocity += GetGravity() * (float)delta;

        Godot.Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        inputDirection = inputDirection * 400 * (float)delta;

        Velocity = velocity + inputDirection;
        
        MoveAndSlide();
    }

}   
