using Godot;

namespace Components {
	[Tool]
	[GlobalClass]
	public partial class HealthComponent : Node2D {
		
		[Signal]
		public delegate void HealthChangedEventHandler(int health);

		[Signal]
		public delegate void HealthDepletedEventHandler();
		
		private int maxHealth = 100;
		[Export]
		public int MaxHealth {
			get => maxHealth;
			private set {
				maxHealth = value;
				if (Health > MaxHealth) {
					Health = MaxHealth;
				}
			}
		}

		private int health = 100;
		[Export]
		public int Health {
			get => health;
			private set {
				health = value;
				EmitSignal(nameof(HealthChanged), health);
				if (health <= 0) {
					EmitSignal(nameof(HealthDepleted));
				}
			}
		}
	}
}