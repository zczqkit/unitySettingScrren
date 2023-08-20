using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

// The function is adapated from https://stackoverflow.com/questions/64258574/what-is-an-ienumerator-in-c-sharp-and-what-is-it-used-for-in-unity
public class FlappyBirdImageSwitcher : MonoBehaviour
{
    public VisualElement animationImage;
    public Texture2D animationImage1;
    public Texture2D animationImage2;
    private bool isAnimationImage1 = true;

    private Coroutine imageSwitchCoroutine;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        animationImage = root.Q<VisualElement>("animationImage");
        imageSwitchCoroutine = StartCoroutine(SwitchImage());
    }

    private void OnDisable()
    {
        if (imageSwitchCoroutine != null)
        {
            StopCoroutine(imageSwitchCoroutine);
            imageSwitchCoroutine = null;
        }
    }

    IEnumerator SwitchImage()
    {
        while (true)
        {
            if (isAnimationImage1)
            {
                animationImage.style.backgroundImage = Background.FromTexture2D(animationImage1);
            }
            else
            {
                animationImage.style.backgroundImage = Background.FromTexture2D(animationImage2);
            }
            isAnimationImage1 = !isAnimationImage1;
            yield return new WaitForSeconds(0.75f);
        }
    }
}