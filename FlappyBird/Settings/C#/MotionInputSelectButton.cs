using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class MotionInputSelectPage : MonoBehaviour
{
    public MotionInputController MotionInputController;

    [SerializeField] private GameObject targetPageStart;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private SettingsScreenController settingsScreenController;
    [SerializeField] private GameObject pleaseWaitModal;
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
    // The function is adapated from https://stackoverflow.com/questions/64258574/what-is-an-ienumerator-in-c-sharp-and-what-is-it-used-for-in-unity

    void LoadTargetPageNext()
    {
        if (MotionInputController.MotionInput1Button.value || MotionInputController.MotionInput2Button.value || MotionInputController.MotionInput3Button.value)
        {
            StartCoroutine(ShowWaitMessageAndLoadPage());
        }
    }

    IEnumerator ShowWaitMessageAndLoadPage()
    {
        pleaseWaitModal.SetActive(true);
        yield return new WaitForSeconds(5);
        pleaseWaitModal.SetActive(false);
        if (targetPageStart != null)
        {
            targetPageStart.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    void LoadTargetPageBack()
    {
        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
        if (settingsScreenController != null && settingsScreenController.MotionInputToggleButton != null)
        {
            settingsScreenController.MotionInputToggleButton.value = false;
        }
    }

}