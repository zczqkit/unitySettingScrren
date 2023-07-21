using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class motionInputImageSwitcher : MonoBehaviour
{
    public VisualElement motionInputImage;
    public Texture2D motionInputInstructionImage1;
    public Texture2D motionInputInstructionImage2;
    private bool isMotionInputInstructionImage1 = true;

    private Coroutine motionInputimageSwitchCoroutine;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        motionInputImage = root.Q<VisualElement>("MotionInputImage");
        motionInputimageSwitchCoroutine = StartCoroutine(SwitchImage());
    }

    private void OnDisable()
    {
        if (motionInputimageSwitchCoroutine != null)
        {
            StopCoroutine(motionInputimageSwitchCoroutine);
            motionInputimageSwitchCoroutine = null;
        }
    }

    IEnumerator SwitchImage()
    {
        while (true)
        {
            if (isMotionInputInstructionImage1)
            {
                motionInputImage.style.backgroundImage = Background.FromTexture2D(motionInputInstructionImage1);
            }
            else
            {
                motionInputImage.style.backgroundImage = Background.FromTexture2D(motionInputInstructionImage2);
            }
            isMotionInputInstructionImage1 = !isMotionInputInstructionImage1;
            yield return new WaitForSeconds(0.75f);
        }
    }
}