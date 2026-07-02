using Godot;
using System;
using System.Diagnostics;
using System.Numerics;

public partial class Character : CharacterBody2D
{

    public override void _PhysicsProcess(double delta)
    {
        Godot.Vector2 velocity = Velocity;

        velocity += GetGravity() * (float)delta;

        Godot.Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        inputDirection = inputDirection * 400 * (float)delta;

        if (Input.IsActionJustReleased("left"))
        {
        
        
        }

        Velocity = velocity + inputDirection;
        
        MoveAndSlide();
    }

}   
