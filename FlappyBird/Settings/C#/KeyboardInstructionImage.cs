using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class keyboardImageSwitcher : MonoBehaviour
{
    public VisualElement keyboardImage;
    public Texture2D keyboardInstructionImage1;
    public Texture2D keyboardInstructionImage2;
    private bool isKeyboardInstructionImage1 = true;

    private Coroutine keyboardimageSwitchCoroutine;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        keyboardImage = root.Q<VisualElement>("KeyboardImage");
        keyboardimageSwitchCoroutine = StartCoroutine(SwitchImage());
    }

    private void OnDisable()
    {
        if (keyboardimageSwitchCoroutine != null)
        {
            StopCoroutine(keyboardimageSwitchCoroutine);
            keyboardimageSwitchCoroutine = null;
        }
    }

    IEnumerator SwitchImage()
    {
        while (true)
        {
            if (isKeyboardInstructionImage1)
            {
                keyboardImage.style.backgroundImage = Background.FromTexture2D(keyboardInstructionImage1);
            }
            else
            {
                keyboardImage.style.backgroundImage = Background.FromTexture2D(keyboardInstructionImage2);
            }
            isKeyboardInstructionImage1 = !isKeyboardInstructionImage1;
            yield return new WaitForSeconds(0.75f);
        }
    }
}