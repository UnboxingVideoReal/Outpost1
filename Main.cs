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
        /*        SpawnBullet(true, new Vector2(2, 2), 500f, new Vector2(GetViewportRect().Size.X, 0), GetNode<CharacterBody2D>("Enigma").GlobalPosition + new Vector2(GD.RandRange(-360, 360), GD.RandRange(-360, 360)), true, 10);
                SpawnBullet(true, new Vector2(2, 2), 500f, new Vector2(0, 0), GetNode<CharacterBody2D>("Enigma").GlobalPosition + new Vector2(GD.RandRange(-360, 360), GD.RandRange(-360, 360)), true, 10);
                SpawnBullet(true, new Vector2(2, 2), 500f, new Vector2(GetViewportRect().Size.X, GetViewportRect().Size.Y), GetNode<CharacterBody2D>("Enigma").GlobalPosition + new Vector2(GD.RandRange(-360, 360), GD.RandRange(-360, 360)), true, 10);
                SpawnBullet(true, new Vector2(2, 2), 500f, new Vector2(0, GetViewportRect().Size.Y), GetNode<CharacterBody2D>("Enigma").GlobalPosition + new Vector2(GD.RandRange(-360, 360), GD.RandRange(-360, 360)), true, 10);
        */
        SpawnBullet(true, new Vector2(2, 2), 500f, new Vector2(swidth / 2, sheight / 4), GetNode<CharacterBody2D>("Enigma").GlobalPosition + new Vector2(GD.RandRange(-10, 10), GD.RandRange(-10, 10)), true, 10);

    }

    public void SpawnBullet(bool visible, Vector2 scale, float speed, Vector2 position, Vector2 target, bool sound, int soundchance)
    {
        swidth = GetViewportRect().Size.X;
        sheight = GetViewportRect().Size.Y;
        PackedScene bulletscene = (PackedScene)ResourceLoader.Load("res://Bullet.tscn");

        Bullet bullet = (Bullet)bulletscene.Instantiate();

        bullet.Set("Visi", visible);
        bullet.Set("Sizee", scale);
        bullet.Set("Speed", speed);
        bullet.Set("Pos", position);
        bullet.Set("Target", target);
        bullet.Set("Sound", sound);
        bullet.Set("sound1in", soundchance);

        GetTree().Root.AddChild(bullet);

    }
}
