using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace ChangeGame.Manager
{
    public class FinalScoreManager : MonoBehaviour
    {
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private Animator _anim;
        [SerializeField] private string _animNextTriggerName;
        [SerializeField] private Fade _fade;
        [SerializeField] private float _scoreTweenTime = 1.0f;
        [SerializeField] private float _nextScoreTweenTime = 0.5f;
        [SerializeField] private string _nextSceneName;
        
        [Header("UI")]
        [SerializeField] private TMPro.TextMeshProUGUI _timeText;
        [SerializeField] private TMPro.TextMeshProUGUI _eliminatText;
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
        
        private void Start()
        {
            _fade.FadeStart(StartScoreTween);
            
            //テキストを初期化
            _timeText.text = "";
            _eliminatText.text = "";
            _scoreText.text = "";
        }

        private void StartScoreTween()
        {
            //Dotweenで生存時間を表示
            DOTween.To(() => 0, x => _timeText.text = x.ToString("F2"), _scoreSO.SurviveTime, _scoreTweenTime)
                .OnComplete(() =>
                {
                    //Dotweenでエリミネート数を表示
                    DOTween.To(() => 0, x => _eliminatText.text = x.ToString(), _scoreSO.EliminateCount, _scoreTweenTime)
                        .OnComplete(() =>
                        {
                            //Dotweenでスコアを表示
                            DOTween.To(() => 0, x => _scoreText.text = x.ToString(), _scoreSO.Score, _scoreTweenTime)
                                .OnComplete(() =>
                                {
                                    _anim.SetTrigger(_animNextTriggerName);
                                });
                        });
                });
        }

        public void AnimationFinish()
        {
            Debug.Log("アニメーション終了");
            _fade.FadeStart(() =>
            {
                //シーン遷移
                SceneManager.LoadScene(_nextSceneName);
            });
        }
    }
}
