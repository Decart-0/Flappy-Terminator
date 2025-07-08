using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    private void Start()
    {
        WindowPanel.SetActive(true);
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
        PlayButtonClicked?.Invoke();
    }
}