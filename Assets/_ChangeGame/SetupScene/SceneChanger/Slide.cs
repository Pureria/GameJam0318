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
        [SerializeField] private Animator _anim;
        
        protected override void Initialize()
        {
            _sceneChangeEffect = SceneChangeEffect.Slide;
        }
        
        public override bool InSCEffect(float scTime, SceneChangeEffect effect)
        {
            if (!base.InSCEffect(scTime, effect)) return false;
            StartAnimation(scTime);
            return true;
        }

        public override bool OutSCEffect(float scTime, SceneChangeEffect effect)
        {
            if (!base.OutSCEffect(scTime, effect)) return false;
            EndAnimation(scTime);
            return true;
        }

        private void StartAnimation(float time)
        {
            _canvasObject.SetActive(true);
            //アニメーションのスピードをtimeにしてアニメーターのstartトリガーを呼び出す
            _anim.speed = time;
            _anim.SetTrigger("start");
        }

        private void EndAnimation(float time)
        {
            _canvasObject.SetActive(true);
            _anim.speed = time;
            _anim.SetTrigger("end");
        }
    }
}
