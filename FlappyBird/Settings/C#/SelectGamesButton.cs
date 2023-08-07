using UnityEngine;
using UnityEngine.UIElements;

public class SelectGamesPage : MonoBehaviour
{
    [SerializeField] private GameObject targetPageFlappyBird1;
    [SerializeField] private GameObject targetPageFlappyBird2;
    [SerializeField] private GameObject targetPageFlappyBird3;
    [SerializeField] private GameObject targetPageDoodleJump1;
    [SerializeField] private GameObject targetPageDoodleJump2;
    [SerializeField] private GameObject targetPageDoodleJump3;
    [SerializeField] private GameObject backgroundDoodleJump;
    private Button playFlappyBirdButton;
    private Button playDoodleJumpButton;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        playFlappyBirdButton = uiDocument.rootVisualElement.Q<Button>("PlayFlappyBirdButton");
        playDoodleJumpButton = uiDocument.rootVisualElement.Q<Button>("PlayDoodleJumpButton");
        playFlappyBirdButton.clickable.clicked += LoadFlappyBirdPages;
        playDoodleJumpButton.clickable.clicked += LoadDoodleJumpPages;
    }

    private void OnDisable()
    {
        playFlappyBirdButton.clickable.clicked -= LoadFlappyBirdPages;
        playDoodleJumpButton.clickable.clicked -= LoadDoodleJumpPages;
    }

    void LoadFlappyBirdPages()
    {
        gameObject.SetActive(false);
        targetPageFlappyBird1.SetActive(true);
        targetPageFlappyBird2.SetActive(true);
        targetPageFlappyBird3.SetActive(true);

        // Disable the sprite of the Doodle Jump background
        var spriteRenderer = backgroundDoodleJump.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) spriteRenderer.enabled = false;
    }

    void LoadDoodleJumpPages()
    {
        gameObject.SetActive(false);
        targetPageDoodleJump1.SetActive(true);
        targetPageDoodleJump2.SetActive(true);
        targetPageDoodleJump3.SetActive(true);
    }
}