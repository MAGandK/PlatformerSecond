using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RestartWindow : MonoBehaviour
{
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonExit;
    

    private void Start()
    {
        Time.timeScale = 0;
        _buttonRestart.onClick.AddListener(OnRestartButtonClick);
        _buttonExit.onClick.AddListener(OnExitButtonClick);

    }
    
    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        GameManader.Instance.RestartLevel();
    }
    
    private void OnExitButtonClick()
    {
        UIController.Instance.ClosePopup();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
