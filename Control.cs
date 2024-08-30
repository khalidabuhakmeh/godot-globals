using Godot;
using System;

public partial class Control : Godot.Control
{
    public override void _Ready()
    {
        GameManager.Instance.IncrementScore(200);
    }
}
