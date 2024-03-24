using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.CameraImpulse
{
    [CreateAssetMenu(fileName = "CameraImpulseSO", menuName = "ChangeGame/Camera/CameraImpulseSO")]
    public class CameraImpulseSO : ScriptableObject
    {
        public Action OnCallSmallImpulseEvent;
        public Action<float> OnCallSmallImpulseEventWithTime;
        public Action OnCallMediumImpulseEvent;
        public Action<float> OnCallMediumImpulseEventWithTime;
        public Action OnCallLargeImpulseEvent;
        public Action<float> OnCallLargeImpulseEventWithTime;
    }

}
