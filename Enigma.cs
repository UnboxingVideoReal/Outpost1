using Godot;
using System;
using System.IO;
using System.Threading.Tasks;

public partial class Enigma : CharacterBody2D
{
    [Export]
    public Node2D baseNode;
    public int Speed { get; set; } = 350;
    private AnimatedSprite2D _animatedSprite;

    public override void _Ready()
    {
        GD.Print("test");
        Position = new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y - GetViewportRect().Size.Y / 4);
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
/*        SetPhysicsProcess(false);
*/    }
    public override void _PhysicsProcess(double delta)
    {

    }
    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("left"))
        {
            _animatedSprite.Play("left");
        }
        else if (Input.IsActionPressed("right"))
        {
            _animatedSprite.Play("right");
        }
        else
        {
            _animatedSprite.Play("idle");
        }
        if (Input.IsActionPressed("slow"))
        {
            Speed = 125;
        }
        else
        {
            Speed = 350;
        }
        if (Input.IsActionPressed("shoot"))
        {
            PackedScene bulletscene = (PackedScene)ResourceLoader.Load("res://PlayerBullet.tscn");

            Node bullet = bulletscene.Instantiate();

            bullet.Set("Visi", true);
            bullet.Set("Speed", /* GD.RandRange(1,10) */ 50);
            bullet.Set("Pos", this.Position);

            GetTree().Root.AddChild(bullet);

            if (Engine.GetFramesDrawn() % 6 == 0)
            {
                GetNode<AudioStreamPlayer2D>("Sound").Play();
            }    
        }
        if (Input.IsActionJustPressed("dash"))
        {
            if (Input.IsActionPressed("left") || Input.IsActionPressed("right") || Input.IsActionPressed("up") || Input.IsActionPressed("down"))
            {
                PackedScene bulletscene = (PackedScene)ResourceLoader.Load("res://Afterimage.tscn");

                Node bullet = bulletscene.Instantiate();


                bullet.Set("Visi", true);
                bullet.Set("Speed", /* GD.RandRange(1,10) */ 50);
                bullet.Set("Pos", this.Position);
                bullet.Set("Anim", _animatedSprite.Animation);
                bullet.Set("Framee", _animatedSprite.Frame);

                GetTree().Root.AddChild(bullet);

                Vector2 yea = Input.GetVector("left", "right", "up", "down");
                Velocity = yea * Speed * 4;
                MoveAndSlide();
                GetNode<AudioStreamPlayer2D>("Dash").Play();
            }

        }
        Vector2 inputdirection = Input.GetVector("left", "right", "up", "down");
            Velocity = inputdirection * Speed;
            MoveAndSlide();

    }
}
