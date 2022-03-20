using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardTracker : deviceTracker
{
    public AxisKeys[] axisKeys;
    public KeyCode[] buttonKeys;

    private void Reset() {
        im = GetComponent<InputManager>();
        axisKeys = new AxisKeys[im.axisCount];
        buttonKeys = new KeyCode[im.buttonCount];
    }

    public override void Refresh()
    {
        im = GetComponent<InputManager>();

        KeyCode[] newButtons = new KeyCode[im.buttonCount];
        AxisKeys[] newAxes = new AxisKeys[im.axisCount];

        if (buttonKeys != null) {
            for (int i = 0; i < Mathf.Min(newButtons.Length, buttonKeys.Length); i++) {
                newButtons[i] = buttonKeys[i];
            }
        }
        buttonKeys = newButtons;

        if (axisKeys != null)
        {
            for (int i = 0; i < Mathf.Min(newAxes.Length, axisKeys.Length); i++)
            {
                newAxes[i] = axisKeys[i];
            }
        }
        axisKeys = newAxes;
    }

    void Update()
    {
        for (int i = 0; i < buttonKeys.Length; i++) {
            if (Input.GetKey(buttonKeys[i])) {
                data.buttons[i] = true;
                newData = true;
            }
        }

        for (int i = 0; i < axisKeys.Length; i++)
        {
            float val = 0f;
            if (Input.GetKey(axisKeys[i].positive))
            {
                val += 1f;
                newData = true;
            }
            if (Input.GetKey(axisKeys[i].negative))
            {
                val -= 1f;
                newData = true;
            }
            data.axes[i] = val;
        }

        if (newData) {
            im.PassInput(data);
            newData = false;
            data.Reset();
        }
    }
}

[System.Serializable]
public struct AxisKeys {
    public KeyCode positive;
    public KeyCode negative;
}
