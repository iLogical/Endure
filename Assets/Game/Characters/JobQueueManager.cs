using System;
using Godot;

namespace Endure.Assets.Game.Characters;

[GlobalClass]
public partial class JobQueueManager : Node
{
	private JobManager _jobManager;
	private Vector2? _currentJob;
	public event EventHandler<Vector2> DestinationChanged;

	public JobQueueManager()
	{
		_currentJob = null;
	}

	public override void _Ready()
	{
		_jobManager = GetParent<Character>().JobManager;
	}

	public override void _Process(double delta)
	{
		if (!_jobManager.HasJobs())
			return;

		_currentJob ??= _jobManager.TakeJob();
		OnDestinationChanged(_currentJob.Value);
	}

	public void CompleteJob()
	{
		_currentJob = null;
	}

	private void OnDestinationChanged(Vector2 e)
	{
		DestinationChanged?.Invoke(this, e);
	}
}
