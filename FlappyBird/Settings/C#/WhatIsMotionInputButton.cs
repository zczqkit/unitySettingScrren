using UnityEngine;
using UnityEngine.UIElements;

public class WhatIsMotionInputPage : MonoBehaviour
{
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private GameObject MotionInputSelect;
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
        Application.OpenURL("https://xip.cs.ucl.ac.uk/product/UCL-MotionInput-3-noncommercial-use");
    }

    void LoadTargetPageBack()
    {
        gameObject.SetActive(false);

        if (MotionInputSelect != null && MotionInputSelect.activeInHierarchy)
        {
            
            MotionInputSelect.SetActive(false);
        }

        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}