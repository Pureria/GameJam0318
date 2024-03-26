using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace ChangeGame.UI
{
    public class OptionSlider : MonoBehaviour
    {
        [SerializeField] private OptionSO _optionSO;
        [SerializeField] private Slider _masterSlider;
        [SerializeField] private Slider _bgmSlider;
        [SerializeField] private Slider _seSlider;
        [SerializeField] private Slider _mouseXSensitivity;
        [SerializeField] private Slider _mouseYSensitivity;
        [SerializeField] private OptionManager _optionManager;


        private void Start()
        {
            _masterSlider.value = _optionSO.MasterVolume;
            _bgmSlider.value = _optionSO.BGMVolume;
            _seSlider.value = _optionSO.SEVolume;
            _mouseXSensitivity.value = _optionSO.MouseXSensivity;
            _mouseYSensitivity.value = _optionSO.MouseYSensivity;
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

        public void NowMouseSenseX()
        {
            _optionManager.SetMouseXSensivity(_mouseXSensitivity.value);
        }

        public void NowMouseSenseY()
        {
            _optionManager.SetMouseYSensivity(_mouseYSensitivity.value);
        }
    }

}
