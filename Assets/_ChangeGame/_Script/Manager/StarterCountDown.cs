using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ChangeGame.Manager
{
    public class StarterCountDown : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _countDownSE;
        [SerializeField] private AudioClip _startSE;

        public async UniTask StartCountDown(Action endEvent, CancellationToken token)
        {
            Debug.Log("スタートカウントダウン開始");
            //カウントダウンのアニメーション再生
            _anim.SetTrigger("Start");
            //アニメーション終了まで待つ
            await UniTask.WaitUntil(() => _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1, cancellationToken: token);
            
            Debug.Log("スタートカウントダウン終了");
            endEvent?.Invoke();
        }
        
        public void PlayCountDownSE()
        {
            _audioSource.PlayOneShot(_countDownSE);
        }
        
        public void PlayStartSE()
        {
            _audioSource.PlayOneShot(_startSE);
        }
    }
}
