using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsScreenController : MonoBehaviour
{
    private Label MousestatusLabel;
    private Label KeyboardstatusLabel;
    private Label MotionInputstatusLabel;
    private Toggle MouseToggleButton;
    private Toggle KeyboardToggleButton;
    private Toggle MotionInputToggleButton;

    void Start()
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
    }
}