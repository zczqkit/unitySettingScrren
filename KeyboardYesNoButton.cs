using UnityEngine;
using UnityEngine.UIElements;

public class KeyboardModal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private SettingsScreenController settingsScreenController;
    private Button KeyboardYesButton;
    private Button KeyboardNoButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        KeyboardYesButton = uiDocument.rootVisualElement.Q<Button>("KeyboardYesButton");
        KeyboardNoButton = uiDocument.rootVisualElement.Q<Button>("KeyboardNoButton");

        KeyboardYesButton.clickable.clicked += LoadTargetPageNext;
        KeyboardNoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        KeyboardYesButton.clickable.clicked -= LoadTargetPageNext;
        KeyboardNoButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        // Set MouseToggleButton to ON when MouseYesButton is clicked
        if (settingsScreenController != null)
        {
            settingsScreenController.KeyboardToggleButton.value = true;
        }

        gameObject.SetActive(false);
        if (targetPageNext != null)
        {
            targetPageNext.SetActive(true);
        }
    }

    void LoadTargetPageBack()
    {
        // Set MouseToggleButton to OFF when MouseNoButton is clicked
        if (settingsScreenController != null)
        {
            settingsScreenController.KeyboardToggleButton.value = false;
        }

        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}