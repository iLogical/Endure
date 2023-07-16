using Godot;

namespace Endure.Assets.MainMenu;

public partial class Main : Node2D
{
	private void OnPlayPressed()
	{
		GetTree().ChangeSceneToFile("res://Assets/Game/Game.tscn");
	}
	private void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
