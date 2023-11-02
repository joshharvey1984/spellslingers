using System.Collections.Generic;
using Godot;

public partial class Main : Node2D {
	public AudioStreamPlayer2D Music => GetNode<AudioStreamPlayer2D>("Music");

	[Export] public AudioStreamMP3[] TrackList;
	[Export] public Node2D[] MageSpawns;
	[Export] public PackedScene MageScene;
	//[Export] public MageData[] MageDatas;
	
	//public List<Mage> Mages = new List<Mage>();
	
	public override void _Ready() {
		var mage = (Node2D)MageScene.Instantiate();
		var mageEnemy = (Node2D)MageScene.Instantiate();

		mage.Position = MageSpawns[0].Position;
		mageEnemy.Position = MageSpawns[1].Position;

		AddChild(mage);
		AddChild(mageEnemy);

		//var mageScript = (Mage)mage;
		//mageScript.Initialise(PlayerType.LocalPlayer, MageDatas[1]);

		//var mageEnemyScript = (Mage)mageEnemy;
		//mageEnemyScript.Initialise(PlayerType.AIPlayer, MageDatas[0], AIDifficulty.Easy);

		//Mages.Add(mageScript);
		//Mages.Add(mageEnemyScript);

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
