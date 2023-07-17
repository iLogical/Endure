using Godot;

namespace Endure.Assets.Game;

public partial class BuildingManager : Node2D
{
	[Export] private TileMap _tileMap;
	private JobManager _jobManager;
	private WorldGrid _worldGrid;
	private TileSet _tileSet;

	public override void _Ready()
	{
		_jobManager = Managers.Instance.Get<JobManager>();
		_worldGrid = Managers.Instance.Get<WorldGrid>();
		_tileSet = _worldGrid.TileSet;
	}

	public override void _Input(InputEvent @event)
	{
		if (!@event.IsActionPressed("click"))
			return;

		var position = GetGlobalMousePosition();
		_jobManager.AddJob(position);
	}
}
