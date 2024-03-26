using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.AudioSpectrum
{
    public class AudioSpectrum : MonoBehaviour
    {
        public static AudioSpectrum Instance;
        
        public AudioSpectrumSO audioSpectrumSO;
        [SerializeField] private AudioSource _audioSource;
        private const int numSamples = 512; // FFTで使用するサンプル数
        private float[] spectrumData; // スペクトラムデータ

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this.gameObject);
        }

        void Start()
        {
            spectrumData = new float[numSamples / 2]; // 配列の長さを半分にする
        }

        void Update()
        {
            // スペクトルデータの取得
            _audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

            // オブジェクトのScaleをスペクトルデータに基づいて更新
            for (int i = 0; i < audioSpectrumSO.SpectrumData.Length; i++)
            {
                // 各オブジェクトのScaleをスペクトラムデータに応じて変化させる
                float scaleValue = spectrumData[i] * 10f; // 適切なスケール調整を行うことで、より見栄えの良いエフェクトを作成できます。
                //spectrumObjects[i].transform.localScale = new Vector3(1, scaleValue, 1);
                audioSpectrumSO.SpectrumData[i] = scaleValue;
            }
        }
    }
}
