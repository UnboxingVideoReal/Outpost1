using Godot;
using System;
using static Godot.TextServer;

public partial class Bullet : RigidBody2D
{
    public float Speed { get; set; } = 0f;
    public Vector2 Pos { get; set; } = new Vector2(0, 0);
    public bool Visi = false;
    private Vector2 _velocity;
    public Vector2 Target;
    public Vector2 Sizee;
    public bool Sound = false;
    public int sound1in = 10;

    public override void _Ready()
    {
        GetNode<Sprite2D>("Sprite2D").Visible = false;

    }
    public override void _PhysicsProcess(double delta)
    {
        if (Position == new Vector2(0, 0))
        {
            GetNode<Sprite2D>("Sprite2D").Visible = Visi;
            Position = Pos;
            Vector2 direction = (Target - GlobalPosition).Normalized();
            _velocity = direction * Speed;
            Scale = Sizee;
            if (Sound)
            {
                if ((int)GD.RandRange(1,sound1in) == 1)
                GetNode<AudioStreamPlayer2D>("Sound" + ((int)GD.RandRange(1, 3)).ToString()).Play();
            }
        }
        Scale = Sizee;
        MoveAndCollide(_velocity * (float)delta);
        if (GetNode<Area2D>("Area2D").HasOverlappingBodies() == true && GetNode<Area2D>("Area2D").OverlapsBody(GetTree().Root.GetNode<StaticBody2D>("Node2D/bulletcol")) == true)
        {
            QueueFree();
        }

    }
}
