using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public bool _hasLost = false;
    [SerializeField] public float _winTime = 120f;
    private float _elapsedTime = 0f;
    private bool _hasWon = false;
    
    void Update()
    {
        if (_hasLost)
        {
            LostFeedback();
        }
        if (!_hasLost && !_hasWon)
        {
             _elapsedTime += Time.deltaTime;
             
             if (_elapsedTime >= _winTime)
             {
                 WinFeedback();
             }
        }
    }
    
    private void WinFeedback()
    {
        _hasWon = true;
        Debug.Log("You won!");
        Invoke("Reload", 5f);
    }
    
    private void LostFeedback()
    {
        Debug.Log("You lost!");
        Invoke("Reload", 2f);
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
