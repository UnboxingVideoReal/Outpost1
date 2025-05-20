using Godot;
using System;

public partial class Main : Node2D
{
    public float swidth;
    public float sheight;
    public override void _Process(double delta)
    {
        swidth = GetViewportRect().Size.X;
        sheight = GetViewportRect().Size.Y;
        PackedScene bulletscene = (PackedScene)ResourceLoader.Load("res://Bullet.tscn");

        Bullet bullet = (Bullet)bulletscene.Instantiate();

        bullet.Set("Visi", true);
        bullet.Set("Speed", 100f);
        bullet.Set("Pos", new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y / 4));
        bullet.Set("Target", new Vector2(GD.RandRange(-10, 10), GD.RandRange(-10, 10)));

        GetTree().Root.AddChild(bullet);

    }
}
