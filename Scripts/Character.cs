using Godot;

public partial class Character : CharacterBody2D
{
    private float speed = 1600f;


    public override void _PhysicsProcess(double delta)
    {
        // We made our own input direction 
        // This is a vector where X is -speed or speed depending if we press left or right
        Vector2 inputDirection = Vector2.Zero;
        if (Input.IsActionPressed("left")) inputDirection.X -= speed;
        if (Input.IsActionPressed("right")) inputDirection.X += speed;

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

}   
