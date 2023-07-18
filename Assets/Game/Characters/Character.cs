using Godot;

namespace Endure.Assets.Game.Characters;

[GlobalClass]
public partial class Character : CharacterBody2D
{
	[Export] private int Speed { get; set; }
	private NavigationAgent2D _navigationAgent2D;
	private JobQueueManager _jobQueueManager;

	public Character()
	{
		Speed = 100;
	}

	public override void _Ready()
	{
		_jobQueueManager = GetNode<JobQueueManager>("JobQueueManager");
		_jobQueueManager.DestinationChanged += OnTargetPositionChanged;
		_navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = ToLocal(_navigationAgent2D.GetNextPathPosition()).Normalized();

		Velocity = direction * Speed;

		MoveAndSlide();

		if (!_navigationAgent2D.IsNavigationFinished())
			return;

		_jobQueueManager.CompleteJob();
	}

	private void OnTargetPositionChanged(object _, Vector2 newTarget)
	{
		_navigationAgent2D.TargetPosition = newTarget;
	}
}
