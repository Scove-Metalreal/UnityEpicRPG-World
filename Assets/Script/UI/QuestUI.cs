using UnityEngine;
using System;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public static QuestUI instance;

    private Action onConfirm;
    private Action onCancel;

    [SerializeField] private GameObject panel;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Text questNotificationText;

    private void Awake()
    {
        instance = this;

        acceptButton.onClick.AddListener(() =>
        {
            onConfirm?.Invoke();
            Close();
        });

        cancelButton.onClick.AddListener(() =>
        {
            onCancel?.Invoke();
            Close();
        });

        Close();
    }
    public void Open(Action confirm, Action cancel = null)
    {
        onConfirm = confirm;
        onCancel = cancel;
        panel.SetActive(true);
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void OnSubmitButton()
    {
        GameEventsManager.instance.inputEvents.SubmitPressed();
    }
    public void ShowQuestNotification(string message)
    {
        questNotificationText.text = message;
    }
}
