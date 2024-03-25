using System;
using System.Collections;
using System.Collections.Generic;
using ChangeGame.Manager;
using TMPro;
using UnityEngine;

namespace ChangeGame.UI
{
    public class GameScoreBoard : MonoBehaviour
    {
        [SerializeField] private GameManagerSO _gameManagerSO;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private TextMeshProUGUI _elimiText;
        [SerializeField] private TextMeshProUGUI _timeText;

        private bool _isGame = false;
        
        private void OnEnable()
        {
            _gameManagerSO.OnGameStartEvent += StartGame;
            _gameManagerSO.OnGameEndEvent += EndGame;
        }
        
        private void OnDisable()
        {
            _gameManagerSO.OnGameStartEvent -= StartGame;
            _gameManagerSO.OnGameEndEvent -= EndGame;
        }

        private void Update()
        {
            if (!_isGame) return;
            _elimiText.text = _scoreSO.EliminateCount.ToString();
            _timeText.text = _scoreSO.SurviveTime.ToString("F2");
        }

        private void StartGame()
        {
            _isGame = true;
        }
        
        private void EndGame()
        {
            _isGame = false;
        }
    }
}
