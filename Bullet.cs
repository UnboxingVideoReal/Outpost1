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
            Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
        }
        MoveAndCollide(_velocity * (float)delta);

    }

    private void OnBodyEntered(Node body)
    {
        if (body is StaticBody2D)
        {
            GD.Print("Hit a static body (like a wall)");
            QueueFree(); // destroy the bullet
        }
    }

}
