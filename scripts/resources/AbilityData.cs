using System.ComponentModel;
using Godot;

namespace Resources {
	[GlobalClass]
	public partial class AbilityData : Resource {
		[Export] public string Name;
		[Export] public Texture2D Icon;
		[Export] public AbilityType Type;
		[Export] public Texture2D PointTargettingTexture;
	}

	public enum AbilityType {
		TargetArea,
		[Description("Fire a straight line projectile from the caster.")]
		Projectile,
	}
}
