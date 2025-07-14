using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] protected GameObject WindowPanel;

    [SerializeField] private Button _actionButton;

    protected Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public abstract void Open();

    public abstract void Close();
}