using Godot;
using System;

public class StartMenu : Control
{
    public void _on_StartGameButton_pressed()
    {
        GetTree().ChangeScene("res://Scenes/World.tscn");
    }

    public void _on_QuitGameButton_pressed()
    {
        GetTree().Quit();
    }
}
