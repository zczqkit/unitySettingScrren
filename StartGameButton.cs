using UnityEngine;
using UnityEngine.UIElements;

public class StartGamePage : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext1;
    [SerializeField] private GameObject targetPageNext2;
    [SerializeField] private GameObject targetPageNext3;
    [SerializeField] private GameObject targetPageBack;
    private Button startButton;
    private Button backButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        startButton = uiDocument.rootVisualElement.Q<Button>("StartButton");
        backButton = uiDocument.rootVisualElement.Q<Button>("BackButton");

        startButton.clickable.clicked += LoadTargetPageNext;
        backButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        startButton.clickable.clicked -= LoadTargetPageNext;
        backButton.clickable.clicked -= LoadTargetPageBack;
    }

    void LoadTargetPageNext()
    {
        gameObject.SetActive(false);
        if (targetPageNext1 || targetPageNext2 || targetPageNext3 != null) 
        {
            targetPageNext1.SetActive(true);
            targetPageNext2.SetActive(true);
            targetPageNext3.SetActive(true);
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