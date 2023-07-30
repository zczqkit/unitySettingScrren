using UnityEngine;
using UnityEngine.UIElements;

public class MotionInputSelectPage : MonoBehaviour
{
    public MotionInputController MotionInputController;

    [SerializeField] private GameObject targetPageStart;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private SettingsScreenController settingsScreenController;
    private Button nextButton;
    private Button backButton;


    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        nextButton = uiDocument.rootVisualElement.Q<Button>("MotionInputSelectNextButton");
        backButton = uiDocument.rootVisualElement.Q<Button>("MotionInputSelectBackButton");

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
        if (MotionInputController.MotionInput1Button.value || MotionInputController.MotionInput2Button.value || MotionInputController.MotionInput3Button.value
            )
        {
            if (targetPageStart != null)
            {
                targetPageStart.SetActive(true);
            }
        }
    }

    void LoadTargetPageBack()
    {
        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
        // Set MotionInputToggleButton on Controls page to OFF when Back Button on MotionInputSelect Page is clicked
        if (settingsScreenController != null)
        {
            settingsScreenController.MotionInputToggleButton.value = false;
        }
    }

}