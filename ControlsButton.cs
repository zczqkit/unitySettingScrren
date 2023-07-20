using UnityEngine;
using UnityEngine.UIElements;

public class Page : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    private Button nextButton;
    private Button backButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        nextButton = uiDocument.rootVisualElement.Q<Button>("ControlsNextButton");
        backButton = uiDocument.rootVisualElement.Q<Button>("ControlsBackButton");

        nextButton.clickable.clicked += LoadTargetPageNext;
        backButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        nextButton.clickable.clicked -= LoadTargetPageNext;
        backButton.clickable.clicked -= LoadTargetPageBack;
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
}