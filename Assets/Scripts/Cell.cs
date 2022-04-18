using System;
using UnityEngine;

public class Cell
{
    public enum CellAllegiance
    {
        Friendly,
        Evil,
        Neutral,
    }

    private CellAllegiance _allegiance = CellAllegiance.Neutral;
    
    public Vector2 Position { get; }
    public CellComponent Component { private get; set; }

    public Cell(Vector2 position)
    {
        Position = position;
    }

    public void SetAllegiance(CellAllegiance allegiance)
    {
        _allegiance = allegiance;

        var color = allegiance switch
        {
            CellAllegiance.Friendly => Color.green,
            CellAllegiance.Evil => Color.red,
            CellAllegiance.Neutral => Color.white,
            _ => throw new ArgumentOutOfRangeException(nameof(allegiance), allegiance, null)
        };
        
        Component.SetColor(color);
    }
}
