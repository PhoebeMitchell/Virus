using System;
using UnityEngine;
using Random = System.Random;

public class FieldComponent : MonoBehaviour
{
    [SerializeField] private Vector2Int _dimensions;
    [SerializeField] private CellComponent _cell;

    private Field _field;
    
    private void Awake()
    {
        _field = new Field(_dimensions);
        var random = new Random();
        foreach (var cell in _field)
        {
            cell.Component = Instantiate(_cell, cell.Position - _dimensions / 2, Quaternion.Euler(0, 0, 90 * random.Next(0, 4)));
        }
        
        _field.Initialise();
    }
}
