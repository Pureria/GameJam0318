using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.AudioSpectrum
{
    [CreateAssetMenu(fileName = "AudioSpectrumSO", menuName = "ChangeGame/AudioSpectrum/AudioSpectrumSO")]
    public class AudioSpectrumSO : ScriptableObject
    {
        //16の配列を作る
        public float[] SpectrumData = new float[16];
    }
}
