using Godot;

namespace Endure.Assets.Game.Characters;

public partial class Character : CharacterBody2D
{
	[Export] private int Speed { get; set; }
	private NavigationAgent2D _navigationAgent2D;
	private JobManager _jobManager;

	public Character()
	{
		Speed = 100;
	}

	public override void _Ready()
	{
		_jobManager = GetNode<JobManager>("JobManager");
		_jobManager.DestinationChanged += OnTargetPositionChanged;
		_navigationAgent2D = GetNode<NavigationAgent2D>("NavigationAgent2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = ToLocal(_navigationAgent2D.GetNextPathPosition()).Normalized();

		Velocity = direction * Speed;

		MoveAndSlide();
	}

	private void OnTargetPositionChanged(object _, Vector2 newTarget)
	{
		_navigationAgent2D.TargetPosition = newTarget;
	}
}
