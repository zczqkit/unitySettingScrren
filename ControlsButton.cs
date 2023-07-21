using UnityEngine;
using UnityEngine.UIElements;

public class Page : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject whatIsMotionInputPage;
    [SerializeField] private GameObject targetPageBack;
    private Button nextButton;
    private Button backButton;
    private Button whatIsMotionInputButton;


    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        nextButton = uiDocument.rootVisualElement.Q<Button>("ControlsNextButton");
        backButton = uiDocument.rootVisualElement.Q<Button>("ControlsBackButton");
        whatIsMotionInputButton = uiDocument.rootVisualElement.Q<Button>("WhatIsMotionInputButton");

        nextButton.clickable.clicked += LoadTargetPageNext;
        backButton.clickable.clicked += LoadTargetPageBack;
        whatIsMotionInputButton.clickable.clicked += LoadwhatIsMotionInputPage;
    }

    private void OnDisable()
    {
        nextButton.clickable.clicked -= LoadTargetPageNext;
        backButton.clickable.clicked -= LoadTargetPageBack;
        whatIsMotionInputButton.clickable.clicked -= LoadwhatIsMotionInputPage;
    }

    void LoadTargetPageNext()
    {
        gameObject.SetActive(false);
        if (targetPageNext != null)
        {
            targetPageNext.SetActive(true);
        }
    }

    void LoadTargetPageBack()
    {
        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }

    void LoadwhatIsMotionInputPage()
    {
        gameObject.SetActive(false);
        if (whatIsMotionInputPage != null)
        {
            whatIsMotionInputPage.SetActive(true);
        }
    }
}