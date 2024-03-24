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

        public void SetMouseSensivity(float value)
        {
            _optionSO.MouseSensivity = Mathf.Clamp(value, -1, 1);
        }

        public void SetMasterVolume(float value)
        {
            _optionSO.MasterVolume = Mathf.Clamp01(value);
        }

        public void SetBGMVolume(float value)
        {
            _optionSO.BGMVolume = Mathf.Clamp01(value);
        }
        
        public void SetSEVolume(float value)
        {
            _optionSO.SEVolume = Mathf.Clamp01(value);
        }


        public void ReturnTitle()
        {
            SceneManager.LoadScene(_nextSceneName);
        }

    }

}
