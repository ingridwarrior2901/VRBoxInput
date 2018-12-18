using System.Runtime.InteropServices;
using UnityEngine;

namespace VRBox
{
    public class VRBoxBluetoothHandler : MonoBehaviour
    {

#if UNITY_IPHONE
        [DllImport("__Internal")]
        private static extern void _vr_startTrackingBluetoothKey();
        [DllImport("__Internal")]
        private static extern void _vr_stopTrackingBluetoothKey();
#endif

        #region Events

        public delegate void OnVRBoxKeyReceiveDelegate(string inputKey);
        public static event OnVRBoxKeyReceiveDelegate OnVRBoxKeyReceived;

        #endregion

        #region iOS Received Message

        public void VRBoxInputHandler(string inputKey)
        {
            OnVRBoxKeyReceived?.Invoke(inputKey);
        }

        #endregion

        #region Public methods

        public void LoadVRBoxTracking(bool enableKeyTracking)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (enableKeyTracking)
                {
                    StartTrackingBluetoothKey();
                }
                else
                {
                    StopTrackingBluetoothKey();
                }
            }
        }

        #endregion

        #region Private methods

        private void StartTrackingBluetoothKey()
        {
#if UNITY_IPHONE
            _vr_startTrackingBluetoothKey();
#endif
        }

        private void StopTrackingBluetoothKey()
        {
#if UNITY_IPHONE
            _vr_stopTrackingBluetoothKey();
#endif
        }

        #endregion
    }
}
