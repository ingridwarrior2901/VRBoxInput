using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRBox;

public class DemoTextCaptureKeys : MonoBehaviour
{
    public Text text;
    private VRBoxInputManager inputManager;
    private VRBoxBluetoothHandler bluetoothHandler;

    void Start()
    {
        inputManager = FindObjectOfType<VRBoxInputManager>();
        bluetoothHandler = FindObjectOfType<VRBoxBluetoothHandler>();
        bluetoothHandler.LoadVRBoxTracking(true);
    }

    void Update()
    { 
        if (inputManager == null)
        {
            Debug.LogError("Unable to find prefabs make sure to attach VRBoxBluetoothController on your scene");
            return;
        }

        Array vrboxKeys = Enum.GetValues(typeof(VRBoxInputManager.VRBoxKeyCode));

         foreach (VRBoxInputManager.VRBoxKeyCode keyCode in vrboxKeys)
         {
             if (inputManager.GetJoystickButton(keyCode))
             {
                 text.text = keyCode.ToString();

             }
         }
    }
}
