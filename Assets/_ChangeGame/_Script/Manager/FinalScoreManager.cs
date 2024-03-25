using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ChangeGame.Scene;

namespace ChangeGame.Manager
{
    public class FinalScoreManager : MonoBehaviour
    {
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private Animator _anim;
        [SerializeField] private string _animNextTriggerName;
        //[SerializeField] private Fade _fade;
        [SerializeField] private float _scoreTweenTime = 1.0f;
        [SerializeField] private float _nextScoreTweenTime = 0.5f;
        [SerializeField] private string _nextSceneName;
        
        [Header("UI")]
        [SerializeField] private TMPro.TextMeshProUGUI _timeText;
        [SerializeField] private TMPro.TextMeshProUGUI _eliminatText;
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
        
        [Header("Scene Change Info")]
        [SerializeField] private int _nextSceneIndex;  //遷移後のシーン番号
        [SerializeField] private SceneChangeEffect _sceneChangeEffect = SceneChangeEffect.Fade;
        [SerializeField] private float _fadeTime;

        private bool _endScoreTween;
        
        private void Start()
        {
            //_fade.FadeStart(StartScoreTween);
            _endScoreTween = false;
            
            //テキストを初期化
            _timeText.text = "";
            _eliminatText.text = "";
            _scoreText.text = "";
        }

        private void Update()
        {
            if (!SceneManager._instance.LoadedScene && !_endScoreTween)
            {
                _endScoreTween = true;
                StartScoreTween();
            }
        }

        private void StartScoreTween()
        {
            //Dotweenで生存時間を表示
            DOTween.To(() => 0, x => _timeText.text = x.ToString("F2"), _scoreSO.SurviveTime, _scoreTweenTime)
                .OnComplete(() =>
                {
                    //Dotweenでエリミネート数を表示
                    DOTween.To(() => 0, x => _eliminatText.text = x.ToString("F0"), _scoreSO.EliminateCount, _scoreTweenTime)
                        .OnComplete(() =>
                        {
                            //Dotweenでスコアを表示
                            DOTween.To(() => 0, x => _scoreText.text = x.ToString("F0"), _scoreSO.Score, _scoreTweenTime)
                                .OnComplete(() =>
                                {
                                    _anim.SetTrigger(_animNextTriggerName);
                                    _endScoreTween = true;
                                });
                        });
                });
        }

        public void AnimationFinish()
        {
            //Debug.Log("アニメーション終了");
            //シーン遷移
            SceneManager.ChangeSceneWait(_nextSceneIndex, _sceneChangeEffect, _fadeTime);
        }
    }
}
