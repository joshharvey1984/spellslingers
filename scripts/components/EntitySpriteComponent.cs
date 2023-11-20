using Godot;

[GlobalClass]
public partial class EntitySpriteComponent : Sprite2D {
	[Export] public Node2D Target { get; set; }

	public override void _Process(double delta) {
		if (Target == null) return;
		CheckFlip();
	}

	public void CheckFlip() {
		FlipH = Target.GlobalPosition.X > GlobalPosition.X;
	}
}
