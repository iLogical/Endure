using System.Collections.Generic;
using Godot;

namespace Endure.Assets.Game;

  public partial class JobManager : Node
{
	private readonly Queue<Vector2> _jobPositions;

	public JobManager()
	{
		_jobPositions = new();
	}

	public bool HasJobs()
	{
		return _jobPositions.Count > 0;
	}

	public void AddJob(Vector2 position)
	{
		_jobPositions.Enqueue(position);
	}
	
	public Vector2 TakeJob()
	{
		return _jobPositions.Dequeue();
	}
}
