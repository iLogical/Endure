using System;
using Godot;

namespace Endure.Assets.Game;

public partial class BuildingManager : Node2D
{
	[Export] private JobManager _jobManager;
	[Export] private WorldGrid _worldGrid;
	private TileSet _tileSet;

	public override void _Ready()
	{
		_tileSet = _worldGrid.TileSet;
	}

	public override void _Input(InputEvent @event)
	{
		if (!@event.IsActionPressed("click"))
			return;

		var position = GetGlobalMousePosition();
		_jobManager.AddJob(position);

		var mousePosition = _worldGrid.LocalToMap(position);
		_worldGrid.SetCell(0, mousePosition, 0);
	}
}
