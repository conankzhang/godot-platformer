using Godot;
using System;

public class WorldComplete : Area2D
{
    [Export]
    public string nextWorld;

    public void OnWorldCompleteBodyEntered(PhysicsBody2D body)
    {
        if(body.GetName() == "Player")
        {
            GetTree().ChangeScene(nextWorld);
        }
    }
}
