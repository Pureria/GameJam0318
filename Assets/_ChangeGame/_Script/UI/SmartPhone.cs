using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace ChangeGame.UI.SmartPhone
{
    public class SmartPhone : MonoBehaviour
    {
        [SerializeField] private List<Image> _phoneImages = new List<Image>();
        [SerializeField] private float _changeTime = 5.0f;
        [SerializeField] private float _changeInterval = 2.0f;
        private int _nowImageIndex;

        private void Start()
        {
            _nowImageIndex = 0;
            
            foreach (var image in _phoneImages)
            {
                Color color = image.color;
                color.a = 0;
                image.color = color;
            }
            
            WaitChangeImage(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask WaitChangeImage(CancellationToken token)
        {
            while (true)
            {
                await _phoneImages[_nowImageIndex].DOFade(1, _changeTime);
                await UniTask.Delay(TimeSpan.FromSeconds(_changeInterval), cancellationToken: token);
                await _phoneImages[_nowImageIndex].DOFade(0, _changeTime);
                _nowImageIndex++;
                if (_nowImageIndex >= _phoneImages.Count) _nowImageIndex = 0;
            }
        }
    }
}