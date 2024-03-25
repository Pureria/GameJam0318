using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChangeGame.UI
{
    public class OptionManager : MonoBehaviour
    {
        [SerializeField] private OptionSO _optionSO;
        [SerializeField] private string _nextSceneName = "TitleScene";


        private void Start()
        {
            _optionSO.MouseSensivity = 0f;
            _optionSO.MasterVolume = 0.5f;
            _optionSO.BGMVolume = 0.5f;
            _optionSO.SEVolume = 0.5f;
        }
   

        public void SetMouseSensivity(float value)
        {
            _optionSO.MouseSensivity = Mathf.Clamp(value, -1f, 1f);
        }

        public void SetMasterVolume(float value)
        {
            _optionSO.MasterVolume = Mathf.Clamp(value, 0f, 0.5f);
            _optionSO.OnChangeAnyVolumeEvent?.Invoke();
        }

        public void SetBGMVolume(float value)
        {
            _optionSO.BGMVolume = Mathf.Clamp(value, 0.8f, 1f);
            _optionSO.OnChangeAnyVolumeEvent?.Invoke();
        }
        
        public void SetSEVolume(float value)
        {
            _optionSO.SEVolume = Mathf.Clamp01(value);
            _optionSO.OnChangeAnyVolumeEvent?.Invoke();
        }


        public void ReturnTitle()
        {
            SceneManager.LoadScene(_nextSceneName);
        }

    }

}
