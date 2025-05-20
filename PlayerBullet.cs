using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerBullet : RigidBody2D
{
    public int Speed { get; set; } = 3;
    public Vector2 Pos { get; set; } = new Vector2(0,0);
    public bool Visi = false;

    public override void _Ready()
    {
        GetNode<Sprite2D>("Sprite2D").Visible = false;
    }
    public override void _PhysicsProcess(double delta)
    {
        if (Position == new Vector2(0,0))
        {
            GetNode<Sprite2D>("Sprite2D").Visible = Visi;
            (GetNode<Sprite2D>("Sprite2D").Material as ShaderMaterial).SetShaderParameter("hue_shift", 9f / 180f);
            (GetNode<Sprite2D>("Sprite2D").Material as ShaderMaterial).SetShaderParameter("alpha", 0.5f);
            Position = Pos;

        }
        LinearVelocity = new Vector2(0, -Speed);
        MoveAndCollide(LinearVelocity);
    }

}
