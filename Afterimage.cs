using Godot;
using System;
using static Godot.TextServer;

public partial class Afterimage : AnimatedSprite2D
{
    public Vector2 Pos { get; set; } = new Vector2(0, 0);
    public bool Visi = false;
    public int Framee = 0;
    public string Anim = "idle";
    float wawa = 1f;

    public override void _Ready()
    {
        GD.Print("Ready start");
        GD.Print("Visi = ", Visi);
        GD.Print("Pos = ", Pos);

        Position = Pos;
        Animation = Anim;
        Frame = Framee;

    }

    public override void _Process(double delta)
    {
        wawa -= 0.1f;
        (Material as ShaderMaterial).SetShaderParameter("alpha", wawa);
        if (wawa <= 0.1f)
        {
            QueueFree();
        }
    }
}
