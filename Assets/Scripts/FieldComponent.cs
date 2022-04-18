using UnityEngine;
using Random = System.Random;

public class FieldComponent : MonoBehaviour
{
    [SerializeField] private Vector2Int _dimensions;
    [SerializeField] private CellComponent _cell;
    [SerializeField] private Connector _connector;

    private Field _field;
    private CellManager _cellManager = new CellManager();
    
    private void Awake()
    {
        
        _field = new Field(_dimensions, _cellManager);
        var random = new Random();
        foreach (var cell in _field)
        {
            var cellPosition = (Vector2)(cell.Position - _dimensions / 2);
            cell.Component = Instantiate(_cell, cellPosition, Quaternion.Euler(0, 0, 90 * random.Next(0, 4)));
            cell.Component.CellManager = _cellManager;
            
            var cellUp = _field.GetCellAtPosition(cell.Position + Vector2Int.up);
            if (cellUp != null)
            {
                var connectorUp = Instantiate(_connector, cellPosition, Quaternion.identity);
                cell.Connectors.Up = connectorUp;
                cellUp.Connectors.Down = connectorUp;
            }

            var cellRight = _field.GetCellAtPosition(cell.Position + Vector2Int.right);
            if (cellRight != null)
            {
                var connectorRight = Instantiate(_connector, cellPosition, Quaternion.Euler(0, 0, -90));
                cell.Connectors.Right = connectorRight;
                cellRight.Connectors.Left = connectorRight;
            }
        }
        
        _field.Initialise();
    }
}
