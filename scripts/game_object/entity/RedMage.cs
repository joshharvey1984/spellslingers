using Godot;
using Resources;

public partial class RedMage : CharacterBody2D, IMage {
	[Export] public MageData MageData { get; set; }
    [Export] public EntitySpriteComponent SpriteComponent { get; set; }
}
