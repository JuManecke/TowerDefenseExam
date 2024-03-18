using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPositionManager : MonoBehaviour
{
    public FieldState[,] PositionTracker;
    public float gridSize = 1.0f; // Size of each grid cell

    public enum FieldState
    {
        Empty,
        Occupied,
        Blocked
    }

    private void Start()
    {
        InitializePositionTracker();
    }
    
    private void InitializePositionTracker()
    {
        PositionTracker = new FieldState[,]
        {
            { FieldState.Empty, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Blocked, FieldState.Empty,   FieldState.Empty,   FieldState.Empty },
            { FieldState.Empty, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Empty,   FieldState.Blocked, FieldState.Blocked, FieldState.Blocked, FieldState.Empty },
            { FieldState.Empty, FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty,   FieldState.Empty }
        };
    }
}
