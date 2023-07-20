using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsScreenController : MonoBehaviour
{
    private Label statusLabel;
    private Toggle myToggleButton;

    void Start()
    {
        var UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;

        // Find the toggle button and the label
        myToggleButton = root.Q<Toggle>("myToggleButton");
        statusLabel = root.Q<Label>("statusLabel");

        // Attach the change event handler
        myToggleButton.RegisterCallback<ChangeEvent<bool>>(OnToggleButtonChanged);
    }

    void OnToggleButtonChanged(ChangeEvent<bool> evt)
    {
        // Change the label text and color based on the toggle button state
        if (evt.newValue)
        {
            statusLabel.text = "ON";
            statusLabel.style.color = Color.green;
        }
        else
        {
            statusLabel.text = "OFF";
            statusLabel.style.color = Color.red;
        }
    }
}