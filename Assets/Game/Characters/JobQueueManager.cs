using System;
using Godot;

namespace Endure.Assets.Game.Characters;

public partial class JobQueueManager : Node2D
{
	private Vector2? _currentJob;
	private JobManager _jobManager;
	public event EventHandler<Vector2> DestinationChanged;

	public JobQueueManager()
	{
		_currentJob = null;
	}

	public override void _Ready()
	{
		_jobManager = Managers.Instance.Get<JobManager>();
	}

	public override void _Process(double delta)
	{
		if(!_jobManager.HasJobs())
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
