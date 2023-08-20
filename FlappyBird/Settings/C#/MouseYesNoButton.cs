using UnityEngine;
using UnityEngine.UIElements;

public class MouseModal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private SettingsScreenController settingsScreenController;
    private Button MouseYesButton;
    private Button MouseNoButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        MouseYesButton = uiDocument.rootVisualElement.Q<Button>("MouseYesButton");
        MouseNoButton = uiDocument.rootVisualElement.Q<Button>("MouseNoButton");

        MouseYesButton.clickable.clicked += LoadTargetPageNext;
        MouseNoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        MouseYesButton.clickable.clicked -= LoadTargetPageNext;
        MouseNoButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        if (settingsScreenController != null)
        {
            settingsScreenController.MouseToggleButton.value = true;
        }

        gameObject.SetActive(false);
        if (targetPageNext != null)
        {
            targetPageNext.SetActive(true);
        }
    }

    void LoadTargetPageBack()
    {
        if (settingsScreenController != null)
        {
            settingsScreenController.MouseToggleButton.value = false;
        }

        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}