using System.Data.Common;
using Godot;

public partial class Character : CharacterBody2D
{
    private float speed = 1600f;
    private AnimatedSprite2D Curro;

    public override void _PhysicsProcess(double delta)
    {
        Movement(delta);
        Flip();
    }

    public void Movement(double delta)
    {
        
        Curro = GetNode<AnimatedSprite2D>("Animations");
        // We made our own input direction 
        // This is a vector where X is -speed or speed depending if we press left or right

        // When moving in any x direction it play the correct animation while the character moves
        Vector2 inputDirection = Vector2.Zero;
        if (Input.IsActionPressed("left")) 
        {
            inputDirection.X -= speed;
            Curro.Play("RunAnimation");
        }
        if (Input.IsActionPressed("right")) 
        {
            inputDirection.X += speed;
            Curro.Play("RunAnimation");
        }
        // Make Character be in Stoping animation if the player is stoping moving
        if (Input.IsActionJustReleased("left") || Input.IsActionJustReleased("right")) Curro.Play("Stoping");

        // This is the acceleration, it uses the input direction and gravity
        // It takes into account delta time, meaning that its now in p/s instead of p/frame
        Vector2 acceleration = (inputDirection + GetGravity()) * (float)delta;

        // Jump logic, its applied to velocity instead of acceleration because its a single impulse, instead of over time
        if (Input.IsActionJustPressed("up") && IsOnFloor()) Velocity += new Vector2(0, -500);

        // Applying the acceleration to the Velocity and apply air resistance
        Velocity += acceleration;
        Velocity *= new Vector2(0.95f, 1f);
        
        MoveAndSlide();
    }

    public void Flip()
    {
        Curro = GetNode<AnimatedSprite2D>("Animations");
        // In order to flip the the Character
        if (Velocity.X > 0) Curro.FlipH = false;
        if (Velocity.X < 0) Curro.FlipH = true;
        // This is only for make the animation play when the game start
        if (Velocity.X == 0) Curro.Play("Idle");

    }

}
