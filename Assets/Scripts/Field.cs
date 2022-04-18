using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : IEnumerable<Cell>
{
    private Vector2Int _dimensions;
    private readonly Cell[,] _cells;

    public Field(Vector2Int dimensions, CellManager cellManager)
    {
        _dimensions = dimensions;
        _cells = new Cell[dimensions.x, dimensions.y];
        for (var x = 0; x < dimensions.x; x++)
        {
            for (var y = 0; y < dimensions.y; y++)
            {
                _cells[x, y]= new Cell(new Vector2Int(x, y), this);
            }
        }
    }

    public Cell GetCellAtPosition(Vector2Int position)
    {
        try
        {
            return _cells[position.x, position.y];
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    } 

    public void Initialise()
    {
        _cells[0, _dimensions.y - 1].SetAllegiance(Cell.CellAllegiance.Friendly);
        _cells[_dimensions.x - 1, 0].SetAllegiance(Cell.CellAllegiance.Evil);
        _cells[0, _dimensions.y - 1].Fill(Cell.CellAllegiance.Friendly);
        _cells[_dimensions.x - 1, 0].Fill(Cell.CellAllegiance.Evil);
    }

    IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
    {
        return _cells.Cast<Cell>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _cells.GetEnumerator();
    }
}