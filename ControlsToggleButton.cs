using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsScreenController : MonoBehaviour
{
    [SerializeField] private GameObject MouseInstructionModal;
    [SerializeField] private GameObject KeyboardInstructionModal;
    [SerializeField] private GameObject MotionInputSeclect;
    [SerializeField] private Button controlsNextButton;
    private Label MousestatusLabel;
    private Label KeyboardstatusLabel;
    private Label MotionInputstatusLabel;
    [SerializeField] public Toggle MouseToggleButton;
    [SerializeField] public Toggle KeyboardToggleButton;
    [SerializeField] public Toggle MotionInputToggleButton;


void OnEnable()
    {
        var UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;

        // Find the toggle button and the label
        MouseToggleButton = root.Q<Toggle>("MouseToggleButton");
        MousestatusLabel = root.Q<Label>("MousestatusLabel");

        KeyboardToggleButton = root.Q<Toggle>("KeyboardToggleButton");
        KeyboardstatusLabel = root.Q<Label>("KeyboardstatusLabel");

        MotionInputToggleButton = root.Q<Toggle>("MotionInputToggleButton");
        MotionInputstatusLabel = root.Q<Label>("MotionInputstatusLabel");

        // Attach the change event handler
        MouseToggleButton.RegisterCallback<ChangeEvent<bool>>(OnMouseToggleButtonChanged);

        KeyboardToggleButton.RegisterCallback<ChangeEvent<bool>>(OnKeyboardToggleButtonChanged);

        MotionInputToggleButton.RegisterCallback<ChangeEvent<bool>>(OnMotionInputToggleButtonChanged);

        controlsNextButton = root.Q<Button>("ControlsNextButton");
        CheckToggleStatus();
    }

    void CheckToggleStatus()
    {
        if (MouseToggleButton.value || KeyboardToggleButton.value || MotionInputToggleButton.value)
        {
            controlsNextButton.SetEnabled(true);
        }
        else
        {
            controlsNextButton.SetEnabled(false);
        }
    }

    void OnMouseToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            MousestatusLabel.text = "ON";
            MousestatusLabel.style.color = Color.green;
        }
        else
        {
            MousestatusLabel.text = "OFF";
            MousestatusLabel.style.color = Color.red;
        }

        // Show or hide the MouseInstructionModal based on the toggle button state
        if (evt.newValue)
        {
            MouseInstructionModal.SetActive(true); // Show the modal
        }
        else
        {
            MouseInstructionModal.SetActive(false); // Hide the modal
        }

        CheckToggleStatus();
    }


    void OnKeyboardToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            KeyboardstatusLabel.text = "ON";
            KeyboardstatusLabel.style.color = Color.green;
        }
        else
        {
            KeyboardstatusLabel.text = "OFF";
            KeyboardstatusLabel.style.color = Color.red;
        }

        // Show or hide the MouseInstructionModal based on the toggle button state
        if (evt.newValue)
        {
            KeyboardInstructionModal.SetActive(true); // Show the modal
        }
        else
        {
            KeyboardInstructionModal.SetActive(false); // Hide the modal
        }

        CheckToggleStatus();
    }

    void OnMotionInputToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            MotionInputstatusLabel.text = "ON";
            MotionInputstatusLabel.style.color = Color.green;
        }
        else
        {
            MotionInputstatusLabel.text = "OFF";
            MotionInputstatusLabel.style.color = Color.red;
        }
        // Show or hide the MouseInstructionModal based on the toggle button state
        if (evt.newValue)
        {
            MotionInputSeclect.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            MotionInputSeclect.SetActive(false); 
        }

        CheckToggleStatus();
    }
}