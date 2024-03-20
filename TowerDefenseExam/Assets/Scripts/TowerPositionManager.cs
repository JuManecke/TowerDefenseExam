using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerPositionManager : MonoBehaviour
{
    public FieldState[,] PositionStatus;
    public Transform[,] PositionTransform;
    [SerializeField] private GameObject[]                   firstColumnPositions,       secondColumnPositions,  thirdColumnPositions, fourthColumnPositions, 
        fifthColumnPositions,       sixthColumnPositions,   seventhColumnPositions,     eighthColumnPositions,  ninthColumnPositions, tenthColumnPositions,
        eleventhColumnPositions,    twelfthColumnPositions, thirteenthColumnPositions,  fourteenthColumnPositions;

    public enum FieldState
    {
        Empty,
        Occupied,
        Blocked
    }

    private void Start()
    {
        InitializePositionStatus();
        InitializeTransformArray();
    }
    
    private void InitializePositionStatus()
    {
        PositionStatus = new FieldState[,]
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

    private void InitializeTransformArray()
    {
        int numRows = 10;
        int numCols = 14;

        PositionTransform = new Transform[numRows, numCols];
        
        // UNITTEST for the length of the column arrays
        
        for (int col = 0; col < numCols; col++)
        {
            GameObject[] columnArray = GetColumnArray(col);
            
            if (columnArray == null)
            {
                Debug.LogError($"Column {col} GameObject array is null.");
                continue;
            }

            if (columnArray.Length < numRows)
            {
                Debug.LogError($"Column {col} has an incorrect number of elements.");
                continue;
            }

            for (int row = 0; row < numRows; row++)
            {
                PositionTransform[row, col] = columnArray[row].transform;
            }
        }
    }
    
    private GameObject[] GetColumnArray(int column)
    {
        return column switch
        {
            0  => firstColumnPositions,
            1  => secondColumnPositions,
            2  => thirdColumnPositions,
            3  => fourthColumnPositions,
            4  => fifthColumnPositions,
            5  => sixthColumnPositions,
            6  => seventhColumnPositions,
            7  => eighthColumnPositions,
            8  => ninthColumnPositions,
            9  => tenthColumnPositions,
            10 => eleventhColumnPositions,
            11 => twelfthColumnPositions,
            12 => thirteenthColumnPositions,
            13 => fourteenthColumnPositions,
            _  => null
        };
    }
 }
