using UnityEngine;
using UnityEngine.UIElements;

public class SelectGamesPage : MonoBehaviour
{
    [SerializeField] private GameObject targetPage1;
    [SerializeField] private GameObject targetPage2;
    [SerializeField] private GameObject targetPage3;
    private Button button;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        button = uiDocument.rootVisualElement.Q<Button>("PlayFlappyBirdButton");
        button.clickable.clicked += LoadTargetPage;
    }

    private void OnDisable()
    {
        button.clickable.clicked -= LoadTargetPage;
    }

    void LoadTargetPage()
    {
        gameObject.SetActive(false);
        targetPage1.SetActive(true);
        targetPage2.SetActive(true);
        targetPage3.SetActive(true);
    }
}