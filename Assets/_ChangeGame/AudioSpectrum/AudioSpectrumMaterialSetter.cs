using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.AudioSpectrum
{
    public class AudioSpectrumMaterialSetter : MonoBehaviour
    {
        [SerializeField] private AudioSpectrumSO audioSpectrumSO;
        [SerializeField] private GetAudioData audioData;
        //[SerializeField] private Material mat;
        [Tooltip("バー16本にそれぞれサンプル番号(周波数)を割り当てる、数字は0以上GetSpectrum.FFT_res以下。サンプルごとの実際の周波数はFk = outputSampleRate * 0.5 * sampleNum / FFT_res")]
        [SerializeField] private int[] indices;
        [SerializeField] private float amp = 10;

        private int res;
        private void OnEnable()
        {
            res = (int)audioData.FFT_res;
        }

        public void FixedUpdate()
        {
            SetData();
        }

        private void SetData()
        {
            for(int i = 0; i < indices.Length; i++)
            {
                float dat = audioData.spectrumData[Mathf.Clamp(indices[i], 0, res - 1)];
                audioSpectrumSO.SpectrumData[i] = Mathf.Clamp01(dat * amp);
            }
        }
    }
}
