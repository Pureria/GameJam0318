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
        }
   

        public void SetMouseXSensivity(float value)
        {
            _optionSO.MouseXSensivity = value;
        }
        
        public void SetMouseYSensivity(float value)
        {
            _optionSO.MouseYSensivity = value;
        }

        public void SetMasterVolume(float value)
        {
            Debug.Log("MasterVolume : " + value);
            _optionSO.MasterVolume = value;
            _optionSO.OnChangeAnyVolumeEvent?.Invoke();
        }

        public void SetBGMVolume(float value)
        {
            _optionSO.BGMVolume = value;
            _optionSO.OnChangeAnyVolumeEvent?.Invoke();
        }
        
        public void SetSEVolume(float value)
        {
            _optionSO.SEVolume = value;
            _optionSO.OnChangeAnyVolumeEvent?.Invoke();
        }


        public void ReturnTitle()
        {
            SceneManager.LoadScene(_nextSceneName);
        }

    }

}
