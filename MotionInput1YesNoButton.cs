using UnityEngine;
using UnityEngine.UIElements;

public class MotionInputModal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private MotionInputController MotionInputController;
    private Button MotionInputYesButton;
    private Button MotionInputNoButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        MotionInputYesButton = uiDocument.rootVisualElement.Q<Button>("MotionInputYesButton");
        MotionInputNoButton = uiDocument.rootVisualElement.Q<Button>("MotionInputNoButton");

        MotionInputYesButton.clickable.clicked += LoadTargetPageNext;
        MotionInputNoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        MotionInputYesButton.clickable.clicked -= LoadTargetPageNext;
        MotionInputNoButton.clickable.clicked -= LoadTargetPageBack;
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