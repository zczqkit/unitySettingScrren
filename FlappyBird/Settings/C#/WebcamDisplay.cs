using UnityEngine;
using UnityEngine.UI;

public class WebcamDisplay : MonoBehaviour
{
    WebCamTexture webcamTexture;

    void Start()
    {
        // Specify the name of the virtual camera here
        webcamTexture = new WebCamTexture();
        GetComponent<RawImage>().texture = webcamTexture;
        webcamTexture.Play();
    }
}
