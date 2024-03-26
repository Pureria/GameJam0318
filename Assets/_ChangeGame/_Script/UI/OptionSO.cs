using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

namespace ChangeGame.UI
{
    [CreateAssetMenu(fileName = "OptionSO", menuName = "ChangeGame/UI/OptionSO")]
    public class OptionSO : ScriptableObject
    {
        public float MouseXSensivity = 0f;
        public float MouseYSensivity = 0f;
        public float MasterVolume = 0.8f;
        public float BGMVolume = 0.5f;
        public float SEVolume = 0.6f;

        public Action OnChangeAnyVolumeEvent;
    }

}
