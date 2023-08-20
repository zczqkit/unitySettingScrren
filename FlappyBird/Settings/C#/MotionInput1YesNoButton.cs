using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

public class MotionInput1Modal : MonoBehaviour
{
    [SerializeField] private GameObject targetPageNext;
    [SerializeField] private GameObject targetPageBack;
    [SerializeField] private MotionInputController MotionInputController;
    private Button MotionInput1YesButton;
    private Button MotionInput1NoButton;

    // The function is adapated from  https://social.msdn.microsoft.com/Forums/vstudio/en-US/e6d01c90-f8c4-49b8-b945-4d793311b6cc/keyeventfkeyup-not-releasing-keys-as-expected?forum=csharpgeneral
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    const int KEYEVENTF_EXTENDEDKEY = 0x0001;
    const int KEYEVENTF_KEYUP = 0x0002;
    const int VK_RETURN = 0x0D;

    public GameObject errorMessageObject;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        MotionInput1YesButton = uiDocument.rootVisualElement.Q<Button>("MotionInput1YesButton");
        MotionInput1NoButton = uiDocument.rootVisualElement.Q<Button>("MotionInput1NoButton");

        MotionInput1YesButton.clickable.clicked += LoadTargetPageNext;
        MotionInput1NoButton.clickable.clicked += LoadTargetPageBack;
    }

    private void OnDisable()
    {
        MotionInput1YesButton.clickable.clicked -= LoadTargetPageNext;
        MotionInput1NoButton.clickable.clicked -= LoadTargetPageBack;
    }

    // The function is adapated from  https://stackoverflow.com/questions/3594223/how-can-i-fetch-a-customized-folder-path-using-getfolderpath
    // The function is adapated from  https://stackoverflow.com/questions/17321289/use-process-start-with-parameters-and-spaces-in-path
    void LoadTargetPageNext()
    {
        if (MotionInputController != null)
        {
            MotionInputController.MotionInput1Button.value = true;
        }

        gameObject.SetActive(false);
        errorMessageObject.SetActive(false);

        try
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = System.IO.Path.Combine(path, "Programs\\UCL MotionInput v3\\MI3 Facial Navigation v3.2\\MI3-Facial-Navigation-3.2-MFC.exe");

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = path;
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(path);

            Process.Start(psi);

            Thread.Sleep(1000);
            PressKey(VK_RETURN);

            Thread.Sleep(300);
            PressKey(VK_RETURN);
        }
        catch (Exception)
        {
            errorMessageObject.SetActive(true);

            if (MotionInputController != null)
            {
                MotionInputController.MotionInput1Button.value = false; 
            }
        }

        static void PressKey(int keyCode)
        {
            keybd_event((byte)keyCode, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((byte)keyCode, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        if (targetPageNext != null)
        {
            targetPageNext.SetActive(true);
        }
    }

    void LoadTargetPageBack()
    {
        if (MotionInputController != null)
        {
            MotionInputController.MotionInput1Button.value = false;
        }

        gameObject.SetActive(false);
        if (targetPageBack != null)
        {
            targetPageBack.SetActive(true);
        }
    }
}