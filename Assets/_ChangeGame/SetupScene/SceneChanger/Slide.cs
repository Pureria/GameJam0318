using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace ChangeGame.Scene
{
    public class Slide : SceneChangerBase
    {
        //[SerializeField] private Animator _anim;
        [SerializeField] private GameObject _canvasObject;
        [SerializeField] private Image _panel;
        
        protected override void Initialize()
        {
            _sceneChangeEffect = SceneChangeEffect.Slide;
        }
        
        public override bool InSCEffect(float scTime, SceneChangeEffect effect)
        {
            if (!base.InSCEffect(scTime, effect)) return false;
            StartSC(scTime);
            return true;
        }

        public override bool OutSCEffect(float scTime, SceneChangeEffect effect)
        {
            if (!base.OutSCEffect(scTime, effect)) return false;
            EndSC(scTime);
            return true;
        }

        private void StartSC(float time)
        {
            _canvasObject.SetActive(true);
            //_panelのFillAmountをtime秒かけて0にする
            _panel.fillAmount = 1;
            _panel.DOFillAmount(0, time).onComplete += () =>
            {
                _canvasObject.SetActive(false);
            };
            
        }

        private void EndSC(float time)
        {
            _canvasObject.SetActive(true);
            _panel.fillAmount = 0;
            _panel.DOFillAmount(1, time).onComplete += () =>
            {
            };
        }
    }
}
