using Godot;

public partial class Main : Node2D {
	public AudioStreamPlayer2D Music => GetNode<AudioStreamPlayer2D>("Music");

	[Export] public AudioStreamMP3[] TrackList;
	[Export] public Node2D[] MageSpawns;
	[Export] public PackedScene MageScene1;
	[Export] public PackedScene MageScene2;
	[Export] public PackedScene InputComponent;
	[Export] public PackedScene AIComponent;
	
	public override void _Ready() {
		var mage = (CharacterBody2D)MageScene1.Instantiate();
		var mageEnemy = (CharacterBody2D)MageScene2.Instantiate();

		mage.Position = MageSpawns[0].Position;
		mageEnemy.Position = MageSpawns[1].Position;

		AddChild(mage);
		AddChild(mageEnemy);

		var inputComponent = (Node2D)InputComponent.Instantiate();
		mage.AddChild(inputComponent);
		var inputComponentScript = (InputComponent)inputComponent;
		inputComponentScript.CharacterBody = mage;
		var mageScript = (IMage)mage;
		mageScript.SpriteComponent.Target = mageEnemy;

		//mageEnemy.AddChild(AIComponent);

		var randomTrack = TrackList[GD.Randi() % TrackList.Length];
		Music.Stream = randomTrack;
		Music.Play();
	}

	public override void _Process(double delta) { 
		if (!Music.Playing) {
			var randomTrack = TrackList[GD.Randi() % TrackList.Length];
			Music.Stream = randomTrack;
			Music.Play();
		}
	}
}
