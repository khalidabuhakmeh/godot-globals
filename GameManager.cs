using Godot;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }
    
    public override void _Ready()
    {
        Instance = this;
    }

    private readonly object @lock = new();
    
    public int Score { get; private set; } = 0;
    
    [Signal]
    public delegate void ScoreChangedEventHandler(int score);

    public int IncrementScore(int amount = 100)
    {
        lock (@lock)
        {
            Score += amount;
            EmitSignal(SignalName.ScoreChanged, Score);
            return Score;
        }
    }
}
