using UnityEngine;
using UnityEngine.UIElements;

public class WhatIsMotionInputPage : MonoBehaviour
{
    [SerializeField] private GameObject targetPageBack;
    private Button downloadButton;
    private Button backButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        downloadButton = uiDocument.rootVisualElement.Q<Button>("DownloadButton");
        backButton = uiDocument.rootVisualElement.Q<Button>("BackButton");

        downloadButton.clickable.clicked += LoadTargetPageNext;
        backButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        downloadButton.clickable.clicked -= LoadTargetPageNext;
        backButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        //MotionInput Download Page
    }

    void LoadTargetPageBack()
    {
        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}