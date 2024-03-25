using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ChangeGame.UI
{
    [CreateAssetMenu(fileName = "OptionSO", menuName = "ChangeGame/UI/OptionSO")]
    public class OptionSO : ScriptableObject
    {
        public float MouseSensivity = 0f;
        public float MasterVolume = 0.8f;
        public float BGMVolume = 0.5f;
        public float SEVolume = 0.6f;

        public Action OnChangeAnyVolumeEvent;
    }

}
