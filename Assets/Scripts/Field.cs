using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : IEnumerable<Cell>
{
    private readonly Cell[,] _field;
    private Vector2Int _dimensions;
    
    public Field(Vector2Int dimensions)
    {
        _dimensions = dimensions;
        _field = new Cell[dimensions.x, dimensions.y];
        for (var x = 0; x < dimensions.x; x++)
        {
            for (var y = 0; y < dimensions.y; y++)
            {
                _field[x, y]= new Cell(new Vector2(x, y));
            }
        }
    }

    public void Initialise()
    {
        _field[0, _dimensions.y - 1].SetAllegiance(Cell.CellAllegiance.Friendly);
        _field[_dimensions.x - 1, 0].SetAllegiance(Cell.CellAllegiance.Evil);
    }

    IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
    {
        return _field.Cast<Cell>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _field.GetEnumerator();
    }
}