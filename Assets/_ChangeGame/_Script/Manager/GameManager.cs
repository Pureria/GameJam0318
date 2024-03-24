using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Fade _fade;
        [SerializeField] private GameManagerSO _gameManagerSO;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private string _nextSceneName;
        private int _eliminateCount;
        private float _startTime;
        private bool _isGame;
        private Transform _playerTransform;
        
        private void Start()
        {
            _fade.FadeStart(GameStart);
        }

        private void OnEnable()
        {
            _gameManagerSO.OnPlayerDeadEvent += GameEnd;
            _gameManagerSO.OnGetEliminateCountEvent += GetEliminateCount;
            _gameManagerSO.OnGetSurviveTimeEvent += GetSurviveTime;
            _gameManagerSO.OnAddEliminateCountEvent += AddEliminateCount;
            _gameManagerSO.OnSetPlayerTransformEvent += SetPlayerTransform;
            _gameManagerSO.OnGetPlayerTransformEvent += GetPlayerTransform;
        }

        private void OnDisable()
        {
            _gameManagerSO.OnPlayerDeadEvent -= GameEnd;
            _gameManagerSO.OnGetEliminateCountEvent -= GetEliminateCount;
            _gameManagerSO.OnGetSurviveTimeEvent -= GetSurviveTime;
            _gameManagerSO.OnAddEliminateCountEvent -= AddEliminateCount;
            _gameManagerSO.OnSetPlayerTransformEvent -= SetPlayerTransform;
            _gameManagerSO.OnGetPlayerTransformEvent -= GetPlayerTransform;
        }

        private void GameStart()
        {
            _gameManagerSO.OnGameStartEvent?.Invoke();
            _eliminateCount = 0;
            _startTime = Time.time;
            _isGame = true;
        }

        private void GameEnd()
        {
            _gameManagerSO.OnGameEndEvent?.Invoke();
            _scoreSO.SurviveTime = GetSurviveTime();
            _scoreSO.EliminateCount = GetEliminateCount();
            _isGame = false;
            
            //次のシーンへ遷移
            _fade.FadeStart(() =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(_nextSceneName);
            });
        }
        
        private void SetPlayerTransform(Transform playerTransform) => _playerTransform = playerTransform;
        private Transform GetPlayerTransform() => _playerTransform;
        private int GetEliminateCount() => _eliminateCount;
        private float GetSurviveTime() => Time.time - _startTime;
        private void AddEliminateCount() => _eliminateCount++;
    }
}
