using UnityEngine;
using UnityEngine.UIElements;

public class MotionInput2Modal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private MotionInputController MotionInputController;
    private Button MotionInput2YesButton;
    private Button MotionInput2NoButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        MotionInput2YesButton = uiDocument.rootVisualElement.Q<Button>("MotionInput2YesButton");
        MotionInput2NoButton = uiDocument.rootVisualElement.Q<Button>("MotionInput2NoButton");

        MotionInput2YesButton.clickable.clicked += LoadTargetPageNext;
        MotionInput2NoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        MotionInput2YesButton.clickable.clicked -= LoadTargetPageNext;
        MotionInput2NoButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        // Set MouseToggleButton to ON when MouseYesButton is clicked
        if (MotionInputController != null)
        {
            MotionInputController.MotionInput2Button.value = true;
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
            MotionInputController.MotionInput2Button.value = false;
        }

        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}