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

    public class CellConnectors
    {
        public Connector Left { get; set; }
        public Connector Right { get; set; }
        public Connector Up { get; set; }
        public Connector Down { get; set; }
    }

    private CellAllegiance _allegiance = CellAllegiance.Neutral;
    private Field _field;

    public Vector2Int Position { get; }
    public CellComponent Component { get; set; }
    public CellConnectors Connectors { get; } = new CellConnectors();
    public bool IsVisited { get; set; }
    
    public Cell(Vector2Int position, Field field)
    {
        Position = position;
        _field = field;
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

    public void Fill(CellAllegiance cellAllegiance)
    {
        if (IsVisited) { return; }
        SetAllegiance(cellAllegiance);
        var cell = _field.GetCellAtPosition(Position + Vector2Int.RoundToInt(Component.transform.right));
        IsVisited = true;
        cell?.Fill(cellAllegiance);
    }
}
