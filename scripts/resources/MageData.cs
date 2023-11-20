using Godot;

namespace Resources {

    [GlobalClass]
    public partial class MageData : Resource {
		[Export] public string Name;
		[Export] public int Health;
		[Export] public float Speed;
		[Export] public float FireRate;
		[Export] public AbilityData[] Abilities;
		public AbilityData PrimaryAbility => Abilities[0];

		public MageData() { }		
	}
}