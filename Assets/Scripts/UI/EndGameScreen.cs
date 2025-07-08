using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    private void Start()
    {
        WindowPanel.SetActive(false);
    }

    public override void Close()
    {
        WindowPanel.SetActive(false);
    }

    public override void Open()
    {
        WindowPanel.SetActive(true);
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}