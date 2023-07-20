//using UnityEngine;
//using UnityEngine.UIElements;

//public class NavigateToControl : MonoBehaviour
//{
//    [SerializeField] private VisualTreeAsset controlScreen;

//    void Start()
//    {
//        var uiDocument = GetComponent<UIDocument>();

//        var aboutNextButton = uiDocument.rootVisualElement.Q<Button>("AboutNextButton");

//        aboutNextButton.clickable.clicked += () => LoadControlScreen(uiDocument);
//    }

//    void LoadControlScreen(UIDocument uiDocument)
//    {
//        uiDocument.rootVisualElement.Clear();
//        var controlScreenRoot = controlScreen.CloneTree();
//        uiDocument.rootVisualElement.Add(controlScreenRoot);
//    }
//}
