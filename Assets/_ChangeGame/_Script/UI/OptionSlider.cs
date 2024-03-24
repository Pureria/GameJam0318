using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ChangeGame.UI
{
    public class OptionSlider : MonoBehaviour
    {
        [SerializeField] private OptionSO _optionSO;
        [SerializeField] private Slider _masterSlider;
        [SerializeField] private Slider _bgmSlider;
        [SerializeField] private Slider _seSlider;
        [SerializeField] private Slider _mouseSensitivity;
        [SerializeField] private OptionManager _optionManager;


        private void Start()
        {
            _masterSlider.value = _optionSO.MasterVolume;
            _bgmSlider.value = _optionSO.BGMVolume;
            _seSlider.value = _optionSO.SEVolume;
            _mouseSensitivity.value = _optionSO.MouseSensivity;

        }

        public void NowMasterVolume()
        {
            _optionManager.SetMasterVolume(_masterSlider.value);
        }

        public void NowBGMVolume()
        {
            _optionManager.SetBGMVolume(_bgmSlider.value);
        }

        public void NowSEVolume()
        {
            _optionManager.SetSEVolume(_seSlider.value);
        }

        public void NowMouseSensitivity()
        {
            _optionManager.SetMouseSensivity(_mouseSensitivity.value);
        }

    }

}
