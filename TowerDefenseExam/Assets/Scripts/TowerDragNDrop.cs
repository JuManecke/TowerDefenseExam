using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class TowerDragNDrop : MonoBehaviour
{
    [SerializeField] private GameObject towerPositionManager;
    private Vector3 _mousePosition, _resetPosition, _previousPosition;
    private bool _hasBeenMovedBefore, _isDragFinished;
    private Transform _correctPosition;
    private Camera _camera;

    void Start()
    {
        _resetPosition = this.transform.position;
        _camera = Camera.main;
        
    }
    
    private Vector3 GetMousePos()
    {
        return _camera.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        _isDragFinished = false;
        gameObject.GetComponent<TowerLogic>().isActive = false;
        _mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (!_isDragFinished)
        {
            transform.position = _camera.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
        }
    }

    private void OnMouseUp()
    {
        Vector3 nearestFieldPosition = IsNearFieldPosition(this.transform.position);
        
        TowerPositionManager.FieldState nearestFieldStatus = IsValidPosition(nearestFieldPosition);
        
        bool isTooCloseToAnotherTower = IsTooCloseToOtherTower(nearestFieldPosition);
        
        switch (nearestFieldStatus)
        {
            case TowerPositionManager.FieldState.Empty:
                
                Debug.Log("Empty");
                
                if (isTooCloseToAnotherTower)
                {
                    if (!_hasBeenMovedBefore)
                    {
                        gameObject.transform.DOMove(_resetPosition, .5f).SetEase(Ease.InOutSine);
                    }
                    else
                    {
                        gameObject.transform.DOMove(_previousPosition, .5f).SetEase(Ease.InOutSine);
                    }
                }
                else
                {
                    this.transform.DOMove(nearestFieldPosition, .5f).SetEase(Ease.InOutSine);
                    gameObject.GetComponent<TowerLogic>().isActive = true;
                    _previousPosition = this.transform.position;
                    _hasBeenMovedBefore = true;
                }
                break;
            case TowerPositionManager.FieldState.Occupied:
                
                Debug.Log("Occupied");
                
                if (!_hasBeenMovedBefore)
                {
                    gameObject.transform.DOMove(_resetPosition, .5f).SetEase(Ease.InOutSine);
                }
                else
                {
                    gameObject.transform.DOMove(_previousPosition, .5f).SetEase(Ease.InOutSine);
                }
                break;
            case TowerPositionManager.FieldState.Blocked:
                
                Debug.Log("Blocked");
                
                if (!_hasBeenMovedBefore)
                {
                    gameObject.transform.DOMove(_resetPosition, .5f).SetEase(Ease.InOutSine);
                }
                else
                {
                    gameObject.transform.DOMove(_previousPosition, .5f).SetEase(Ease.InOutSine);
                }   
                break;
        }
        _isDragFinished = true;
    }

    private Vector3 IsNearFieldPosition(Vector3 pos)
    {
        float minDistance = Mathf.Infinity;
        Vector3 nearestFieldPosition = Vector3.zero; // Initialize to (0, 0, 0) vector

        // Get the TowerPositionManager component once to avoid repetitive calls
        TowerPositionManager positionManager = towerPositionManager.GetComponent<TowerPositionManager>();

        // Iterate through the transforms and statuses in the arrays
        for (int i = 0; i < positionManager.PositionTransform.GetLength(0); i++)
        {
            for (int j = 0; j < positionManager.PositionTransform.GetLength(1); j++)
            {
                // Get the world position of the current transform
                Vector3 worldPosition = positionManager.PositionTransform[i, j].position;

                // Calculate the distance between the current transform and the input position
                float distance = Vector3.Distance(pos, worldPosition);

                // Update the nearest field position if the distance is smaller
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestFieldPosition = worldPosition;
                }
            }
        }
        return nearestFieldPosition;
    }

    private TowerPositionManager.FieldState IsValidPosition(Vector3 pos)
    {
        float minDistance = Mathf.Infinity;
        TowerPositionManager.FieldState nearestFieldStatus = TowerPositionManager.FieldState.Blocked;

        // Get the TowerPositionManager component once to avoid repetitive calls
        TowerPositionManager positionManager = towerPositionManager.GetComponent<TowerPositionManager>();

        // Iterate through the statuses in the array
        for (int i = 0; i < positionManager.PositionTransform.GetLength(0); i++)
        {
            for (int j = 0; j < positionManager.PositionTransform.GetLength(1); j++)
            {
                // Get the world position of the current transform
                Vector3 worldPosition = positionManager.PositionTransform[i, j].position;

                // Calculate the distance between the current transform and the input position
                float distance = Vector3.Distance(pos, worldPosition);

                // Update the nearest field status if the distance is smaller
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestFieldStatus = positionManager.PositionStatus[i, j];
                }
            }
        }
        
        return nearestFieldStatus;
    }
    private bool IsTooCloseToOtherTower(Vector3 pos)
    {
        float radius = .07f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);

        foreach (Collider2D collider in colliders )
        {
            if (collider.gameObject.CompareTag("Player") && collider.gameObject != gameObject)
            {
                Debug.Log("Found tower with Player tag!");
                return true;
            }
        }
        return false;
    }

}
