using UnityEngine;
using UnityEngine.UIElements;

public class MotionInput1Modal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private MotionInputController MotionInputController;
    private Button MotionInput1YesButton;
    private Button MotionInput1NoButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        MotionInput1YesButton = uiDocument.rootVisualElement.Q<Button>("MotionInput1YesButton");
        MotionInput1NoButton = uiDocument.rootVisualElement.Q<Button>("MotionInput1NoButton");

        MotionInput1YesButton.clickable.clicked += LoadTargetPageNext;
        MotionInput1NoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        MotionInput1YesButton.clickable.clicked -= LoadTargetPageNext;
        MotionInput1NoButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        // Set MouseToggleButton to ON when MouseYesButton is clicked
        if (MotionInputController != null)
        {
            MotionInputController.MotionInput1Button.value = true;
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
            MotionInputController.MotionInput1Button.value = false;
        }

        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}