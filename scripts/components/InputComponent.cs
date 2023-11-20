using System;
using Godot;

public partial class InputComponent : Node2D {
	[Export] public CharacterBody2D CharacterBody;
	private Vector2 mousePosition => GetGlobalMousePosition();
	private float Speed = 500;

	[Signal] public delegate void RightClickEventHandler(Vector2 mousePosition);

	public override void _PhysicsProcess(double delta) {
		var velocity = CharacterBody.Velocity;

		var direction = Input.GetVector("Left", "Right", "Up", "Down");
		if (direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else {
			velocity.X = Mathf.MoveToward(CharacterBody.Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(CharacterBody.Velocity.Y, 0, Speed);
		}

		CharacterBody.Velocity = velocity;
		CharacterBody.MoveAndSlide();

		if (Input.IsActionPressed("RightClick")) {
			HandleRightClick();
		}
	}

    private void HandleRightClick() {
        EmitSignal(nameof(RightClick), mousePosition);
    }
}
