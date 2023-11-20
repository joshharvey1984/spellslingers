using Godot;
using Resources;

public interface IMage {
    [Export] MageData MageData { get; set; }
    [Export] EntitySpriteComponent SpriteComponent { get; set; }
}