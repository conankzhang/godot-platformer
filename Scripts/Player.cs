using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export]
    private float maxSpeed = 250.0f;

    [Export]
    private float jumpHeight = -200.0f;

    [Export]
    private float gravity = 9.8f;

    [Export]
    private float acceleration = 50.0f;

    private Vector2 motion;
    private Vector2 up;

    private AnimatedSprite sprite;

    public override void _Ready()
    {
        motion = new Vector2();
        up = new Vector2(0, -1);

        sprite = GetNode<AnimatedSprite>("Sprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        motion.y += gravity;
        bool friction = false;

        if(Input.IsActionPressed("move_right"))
        {
            motion.x = Mathf.Min(motion.x + acceleration, maxSpeed);
            sprite.SetFlipH(false);
            sprite.Play("Run");
        }
        else if(Input.IsActionPressed("move_left"))
        {
            motion.x = Mathf.Max(motion.x - acceleration, -maxSpeed);
            sprite.SetFlipH(true);
            sprite.Play("Run");
        }
        else
        {
            friction = true;
            sprite.Play("Idle");
        }

        if(IsOnFloor())
        {
            if(Input.IsActionJustPressed("move_up"))
            {
                motion.y = jumpHeight;
            }

            if(friction)
            {
                motion.x = Mathf.Lerp(motion.x, 0, 0.2f);
            }
        }
        else
        {
            if(motion.y < 0.0f)
            {
                sprite.Play("Jump");
            }
            else
            {
                sprite.Play("Fall");
            }

            if(friction)
            {
                motion.x = Mathf.Lerp(motion.x, 0, 0.05f);
            }
        }

        motion = MoveAndSlide(motion, up);
    }
}
