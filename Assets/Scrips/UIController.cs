using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    
    [SerializeField] private Transform _canvasParentTransform;
    [SerializeField] private GameObject _uiPopupPrefab;
    [SerializeField] private TMP_Text _gameOverText;
    
    private GameObject _currentPopup;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance =this;
        }
    }
    public void ShowPopup()
    {
        _currentPopup = Instantiate(_uiPopupPrefab);
            
        _currentPopup.transform.SetParent(_canvasParentTransform, false);

        RectTransform rectTransform = _currentPopup.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;

        DOTween.Sequence()
            .Append(_currentPopup.transform.DOScale(1f, 1f))
            .Append(_currentPopup.transform.DOScale(3f, 1f))
            .SetUpdate(true);
    }

    public void ClosePopup()
    {
        if (_currentPopup != null)
        {
            _currentPopup.SetActive(false);
        }
    }
}
