using UnityEngine;
using UnityEngine.UI;

public class WebcamDisplay : MonoBehaviour
{
    WebCamTexture webcamTexture;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        GetComponent<RawImage>().texture = webcamTexture;
        webcamTexture.Play();
    }
}
