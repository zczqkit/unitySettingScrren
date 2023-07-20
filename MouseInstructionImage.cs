using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageSwitcher : MonoBehaviour
{
    public VisualElement mouseImage;
    public Texture2D image1;
    public Texture2D image2;
    private bool isImage1 = true;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        mouseImage = root.Q<VisualElement>("MouseImage");
        StartCoroutine(SwitchImage());
    }

    IEnumerator SwitchImage()
    {
        while (true)
        {
            if (isImage1)
            {
                mouseImage.style.backgroundImage = Background.FromTexture2D(image1);
            }
            else
            {
                mouseImage.style.backgroundImage = Background.FromTexture2D(image2);
            }
            isImage1 = !isImage1;
            yield return new WaitForSeconds(0.75f);
        }
    }
}