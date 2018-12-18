using System.Collections.Generic;
using UnityEngine;

namespace VRBox
{
    public class VRBoxInputManager : MonoBehaviour
    {
        private VRBoxKeyInput currentKeyInput = new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonNone, "");

        public enum VRBoxKeyCode
        {
            JoystickUp,
            JoystickDown,
            JoystickLeft,
            JoystickRight,
            JoystickButtonC,
            JoystickButtonB,
            JoystickButtonD,
            JoystickButtonA,
            JoystickButtonFire1,
            JoystickButtonFire2,
            JoystickButtonNone
        };

        List<VRBoxKeyInput> keyInputs = new List<VRBoxKeyInput>()
    {
        new VRBoxKeyInput(VRBoxKeyCode.JoystickUp, VRBoxConstants.VRBOX_JOYSTICK_UP),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickDown, VRBoxConstants.VRBOX_JOYSTICK_DOWN),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickLeft, VRBoxConstants.VRBOX_JOYSTICK_LEFT),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickRight, VRBoxConstants.VRBOX_JOYSTICK_RIGHT),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonC, VRBoxConstants.VRBOX_JOYSTICK_BUTTON_C),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonB, VRBoxConstants.VRBOX_JOYSTICK_BUTTON_B),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonD, VRBoxConstants.VRBOX_JOYSTICK_BUTTON_D),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonA, VRBoxConstants.VRBOX_JOYSTICK_BUTTON_A),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonFire1, VRBoxConstants.VRBOX_JOYSTICK_BUTTON_FIRE_1),
        new VRBoxKeyInput(VRBoxKeyCode.JoystickButtonFire2, VRBoxConstants.VRBOX_JOYSTICK_BUTTON_FIRE_2)
    };

        #region LifeCycle

        private void OnEnable()
        {
            VRBoxBluetoothHandler.OnVRBoxKeyReceived += InputHandler;
        }

        private void OnDisable()
        {
            VRBoxBluetoothHandler.OnVRBoxKeyReceived -= InputHandler;
        }

        #endregion

        #region Delegate Methods

        private void InputHandler(string key)
        {
            currentKeyInput = keyInputs.Find(vrBoxKeyInput => vrBoxKeyInput.inputCode.Contains(key));
        }

        #endregion

        #region Public Methods

        public bool GetJoystickButton(VRBoxKeyCode keyCode)
        {
            return currentKeyInput.keyCode == keyCode;
        }

        #endregion

        [SerializeField]
        public class VRBoxKeyInput
        {
            public VRBoxKeyCode keyCode;
            public string inputCode;

            public VRBoxKeyInput(VRBoxKeyCode keyCode, string inputCode)
            {
                this.keyCode = keyCode;
                this.inputCode = inputCode;
            }
        }
    }
}