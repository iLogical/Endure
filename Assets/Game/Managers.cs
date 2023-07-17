using System;
using Godot;

namespace Endure.Assets.Game;

public interface IManagers
{
	T Get<T>() where T : Node;
}
public partial class Managers : Node, IManagers
{
	public static readonly IManagers Instance;
	private readonly System.Collections.Generic.Dictionary<Type, string> _mappings;
	private SceneTree _gameLoop;

	static Managers()
	{
		Instance = new Managers();
	}

	private Managers()
	{
		_gameLoop = (SceneTree)Engine.GetMainLoop();
		_mappings = new()
		{
			[typeof(BuildingManager)] = "Game/Managers/BuildingManager",
			[typeof(JobManager)] = "Game/Managers/JobManager",
			[typeof(WorldGrid)] = "Game/World"
		};
	}

	public T Get<T>() where T : Node
	{
		var mapping = _mappings[typeof(T)];
		return _gameLoop.Root.GetNode<T>(mapping);
	}
}
