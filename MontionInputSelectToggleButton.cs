using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MotionInputController : MonoBehaviour
{
    [SerializeField] private GameObject MotionInput1InstructionModal;
    [SerializeField] private GameObject MotionInput2InstructionModal;
    [SerializeField] private GameObject MotionInput3InstructionModal;
    [SerializeField] private Button MotionInputSelectNextButton;
    private Label MotionInput1statusLabel;
    private Label MotionInput2statusLabel;
    private Label MotionInput3statusLabel;
    [SerializeField] public Toggle MotionInput1Button;
    [SerializeField] public Toggle MotionInput2Button;
    [SerializeField] public Toggle MotionInput3Button;


void OnEnable()
    {
        var UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;

        // Find the toggle button and the label
        MotionInput1Button = root.Q<Toggle>("MotionInput1Button");
        MotionInput1statusLabel = root.Q<Label>("MotionInput1statusLabel");

        MotionInput2Button = root.Q<Toggle>("MotionInput2Button");
        MotionInput2statusLabel = root.Q<Label>("MotionInput2statusLabel");

        MotionInput3Button = root.Q<Toggle>("MotionInput3Button");
        MotionInput3statusLabel = root.Q<Label>("MotionInput3statusLabel");

        // Attach the change event handler
        MotionInput1Button.RegisterCallback<ChangeEvent<bool>>(OnMotionInput1ToggleButtonChanged);

        MotionInput2Button.RegisterCallback<ChangeEvent<bool>>(OnMotionInput2ToggleButtonChanged);

        MotionInput3Button.RegisterCallback<ChangeEvent<bool>>(OnMotionInput3ToggleButtonChanged);

        MotionInputSelectNextButton = root.Q<Button>("MotionInputSelectNextButton");
        CheckToggleStatus();
    }

    void CheckToggleStatus()
    {
        if (MotionInput1Button.value || MotionInput2Button.value || MotionInput3Button.value)
        {
            MotionInputSelectNextButton.SetEnabled(true);
        }
        else
        {
            MotionInputSelectNextButton.SetEnabled(false);
        }
    }

    void OnMotionInput1ToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            MotionInput1statusLabel.text = "ON";
            MotionInput1statusLabel.style.color = Color.green;
        }
        else
        {
            MotionInput1statusLabel.text = "OFF";
            MotionInput1statusLabel.style.color = Color.red;
        }

        // Show or hide the MouseInstructionModal based on the toggle button state
        if (evt.newValue)
        {
            MotionInput1InstructionModal.SetActive(true); // Show the modal
        }
        else
        {
            MotionInput1InstructionModal.SetActive(false); // Hide the modal
        }

        CheckToggleStatus();
    }


    void OnMotionInput2ToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            MotionInput2statusLabel.text = "ON";
            MotionInput2statusLabel.style.color = Color.green;
        }
        else
        {
            MotionInput2statusLabel.text = "OFF";
            MotionInput2statusLabel.style.color = Color.red;
        }

        // Show or hide the MouseInstructionModal based on the toggle button state
        if (evt.newValue)
        {
            MotionInput1InstructionModal.SetActive(true); // Show the modal
        }
        else
        {
            MotionInput1InstructionModal.SetActive(false); // Hide the modal
        }

        CheckToggleStatus();
    }

    void OnMotionInput3ToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            MotionInput3statusLabel.text = "ON";
            MotionInput3statusLabel.style.color = Color.green;
        }
        else
        {
            MotionInput3statusLabel.text = "OFF";
            MotionInput3statusLabel.style.color = Color.red;
        }
        // Show or hide the MouseInstructionModal based on the toggle button state
        if (evt.newValue)
        {
            MotionInput1InstructionModal.SetActive(true);
        }
        else
        {
            MotionInput1InstructionModal.SetActive(false);
        }

        CheckToggleStatus();
    }
}