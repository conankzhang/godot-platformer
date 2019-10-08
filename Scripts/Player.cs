using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    private int moveSpeed = 250;

    [Export]
    private int jumpHeight = -200;

    [Export]
    private float gravity = 9.8f;

    private Vector2 motion;
    private Vector2 up;

    public override void _Ready()
    {
        motion = new Vector2();
        up = new Vector2(0, -1);
    }

    public override void _PhysicsProcess(float delta)
    {
        motion.y += gravity;

        if(Input.IsActionPressed("move_right"))
        {
            motion.x = moveSpeed;
        }
        else if(Input.IsActionPressed("move_left"))
        {
            motion.x = -moveSpeed;
        }
        else
        {
            motion.x = 0;
        }

        if(IsOnFloor() && Input.IsActionJustPressed("move_up"))
        {
            motion.y = jumpHeight;
        }

        motion = MoveAndSlide(motion, up);
    }
}
