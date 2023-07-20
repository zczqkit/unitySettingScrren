using UnityEngine;
using UnityEngine.UIElements;

public class AboutPage : MonoBehaviour
{
    [SerializeField] private GameObject targetPage;
    private Button button;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        button = uiDocument.rootVisualElement.Q<Button>("AboutNextButton");
        button.clickable.clicked += LoadTargetPage;
    }

    private void OnDisable()
    {
        button.clickable.clicked -= LoadTargetPage;
    }

    void LoadTargetPage()
    {
        gameObject.SetActive(false);
        targetPage.SetActive(true);
    }
}