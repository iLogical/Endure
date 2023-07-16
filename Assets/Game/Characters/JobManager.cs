using System;
using Godot;

namespace Endure.Assets.Game.Characters;

public partial class JobManager : Node2D
{
	public event EventHandler<Vector2> DestinationChanged; 
	public override void _Input(InputEvent @event)
	{
		if (!@event.IsActionPressed("click"))
			return;

		var globalMousePosition = GetGlobalMousePosition();
		Console.WriteLine(globalMousePosition);
		OnDestinationChanged(globalMousePosition);
	}

	protected virtual void OnDestinationChanged(Vector2 e)
	{
		DestinationChanged?.Invoke(this, e);
	}
}
