using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class TowerDragNDrop : MonoBehaviour
{
    [SerializeField] private GameObject towerPositionManager;
    private Vector3 _mousePosition, _resetPosition, _previousPosition;
    private bool hasBeenMovedBefore, isDragFinished;
    private Transform _correctPosition;     // nur vorübergehend
    private Camera _camera;
    private TowerPositionManager.FieldState[,] _positionTracker;

    void Start()
    {
        _resetPosition = this.transform.position;
        _camera = Camera.main;
        _positionTracker = towerPositionManager.GetComponent<TowerPositionManager>().PositionTracker;
    }
    
    private Vector3 GetMousePos()
    {
        return _camera.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        isDragFinished = false;
        _mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        if (!isDragFinished)
        {
            transform.position = _camera.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
        }
    }
    private void OnMouseUp()
    {
        if (DistanceChecker(_correctPosition.transform.position, .5f)) // check all possible positions
        // (DistanceChecker(AllCorrectForms.transform.position, .5f))
        {
            this.transform.position = _correctPosition.transform.position;
            // this.transform.position = OneCorrectForm.transform.position;
            
            _previousPosition = this.transform.position;
            hasBeenMovedBefore = true;
        }
        else
        {
            if (!hasBeenMovedBefore)
            {
                gameObject.transform.DOMove(_resetPosition, .5f).SetEase(Ease.InOutSine);
            }
            else
            {
                gameObject.transform.DOMove(_previousPosition, .5f).SetEase(Ease.InOutSine);
            }
        }
        isDragFinished = true;
    }

    private bool DistanceChecker(Vector3 pos, float range)
    {
        var position = this.transform.position;
        return Mathf.Abs(position.x - pos.x) <= range &&
               Mathf.Abs(position.y - pos.y) <= range;
    }
}
