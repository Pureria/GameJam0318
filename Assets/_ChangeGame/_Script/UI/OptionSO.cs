using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.UI
{
    [CreateAssetMenu(fileName = "OptionSO", menuName = "ChangeGame/UI/OptionSO")]
    public class OptionSO : ScriptableObject
    {
        public float MouseSensivity;
        public float MasterVolume;
        public float BGMVolume;
        public float SEVolume;
    }

}
