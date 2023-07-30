using UnityEngine;
using UnityEngine.UIElements;

public class MotionInput3Modal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private MotionInputController MotionInputController;
    private Button MotionInput3YesButton;
    private Button MotionInput3NoButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        MotionInput3YesButton = uiDocument.rootVisualElement.Q<Button>("MotionInput3YesButton");
        MotionInput3NoButton = uiDocument.rootVisualElement.Q<Button>("MotionInput3NoButton");

        MotionInput3YesButton.clickable.clicked += LoadTargetPageNext;
        MotionInput3NoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        MotionInput3YesButton.clickable.clicked -= LoadTargetPageNext;
        MotionInput3NoButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        // Set MouseToggleButton to ON when MouseYesButton is clicked
        if (MotionInputController != null)
        {
            MotionInputController.MotionInput3Button.value = true;
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
        if (MotionInputController != null)
        {
            MotionInputController.MotionInput3Button.value = false;
        }

        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}