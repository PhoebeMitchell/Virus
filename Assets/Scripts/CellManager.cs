using System;

public class CellManager
{
    public bool CellRotating { get; set; }
    public event Action OnRotateComplete;

    public void RotationComplete()
    {
        OnRotateComplete?.Invoke();
    }
}