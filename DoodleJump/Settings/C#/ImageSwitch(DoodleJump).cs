using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageSwitcher_Doodle : MonoBehaviour
{
    public VisualElement AnimationBox1;
    public VisualElement AnimationBox2;
    public Texture2D image1_before;
    public Texture2D image1_after;
    public Texture2D image2_before;
    public Texture2D image2_after;
    private bool isImage1 = true;
    private bool isImage2 = true;

    private Coroutine imageSwitchCoroutine;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        AnimationBox1 = root.Q<VisualElement>("AnimationBox1");
        AnimationBox2 = root.Q<VisualElement>("AnimationBox2");
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
            if (isImage1)
            {
                AnimationBox1.style.backgroundImage = Background.FromTexture2D(image1_before);
            }
            else
            {
                AnimationBox1.style.backgroundImage = Background.FromTexture2D(image1_after);
            }

            if (isImage2)
            {
                AnimationBox2.style.backgroundImage = Background.FromTexture2D(image2_before);
            }
            else
            {
                AnimationBox2.style.backgroundImage = Background.FromTexture2D(image2_after);
            }

            isImage1 = !isImage1;
            isImage2 = !isImage2;
            yield return new WaitForSeconds(0.75f);
        }
    }
}