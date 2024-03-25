using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChangeGame.Scene;

namespace ChangeGame.Manager
{
    public class GameManager : MonoBehaviour
    {
        //[SerializeField] private Fade _fade;
        [SerializeField] private GameManagerSO _gameManagerSO;
        [SerializeField] private ScoreSO _scoreSO;
        
        [Header("Scene Change Info")]
        [SerializeField] private int _nextSceneIndex;  //遷移後のシーン番号
        [SerializeField] private SceneChangeEffect _sceneChangeEffect = SceneChangeEffect.Fade;
        [SerializeField] private float _fadeTime;
        
        private int _eliminateCount;
        private float _startTime;
        private bool _isGame;
        private bool _isGameEnd;
        private Transform _playerTransform;
        
        private void Start()
        {
            _scoreSO.Score = 0;
            _isGame = false;
            _isGameEnd = false;
        }

        private void Update()
        {
            if (!_isGame)
            {
                if (!SceneManager._instance.LoadedScene && !_isGameEnd)
                {
                    GameStart();
                }
                return;
            }
            //_scoreSO.Score = (GetEliminateCount() * 100) + (GetSurviveTime() * 10);
            _scoreSO.SurviveTime = GetSurviveTime();
            _scoreSO.EliminateCount = GetEliminateCount();
        }

        private void OnEnable()
        {
            _gameManagerSO.OnPlayerDeadEvent += GameEnd;
            _gameManagerSO.OnGetEliminateCountEvent += GetEliminateCount;
            _gameManagerSO.OnGetSurviveTimeEvent += GetSurviveTime;
            _gameManagerSO.OnAddEliminateCountEvent += AddEliminateCount;
            _gameManagerSO.OnSetPlayerTransformEvent += SetPlayerTransform;
            _gameManagerSO.OnGetPlayerTransformEvent += GetPlayerTransform;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            _gameManagerSO.OnPlayerDeadEvent -= GameEnd;
            _gameManagerSO.OnGetEliminateCountEvent -= GetEliminateCount;
            _gameManagerSO.OnGetSurviveTimeEvent -= GetSurviveTime;
            _gameManagerSO.OnAddEliminateCountEvent -= AddEliminateCount;
            _gameManagerSO.OnSetPlayerTransformEvent -= SetPlayerTransform;
            _gameManagerSO.OnGetPlayerTransformEvent -= GetPlayerTransform;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
            _scoreSO.Score = (GetEliminateCount() * 100) + (GetSurviveTime() * 10);
            _isGame = false;
            _isGameEnd = true;
            
            //次のシーンへ遷移
            SceneManager.ChangeSceneWait(_nextSceneIndex, _sceneChangeEffect, _fadeTime);
        }
        
        private void SetPlayerTransform(Transform playerTransform) => _playerTransform = playerTransform;
        private Transform GetPlayerTransform() => _playerTransform;
        private int GetEliminateCount() => _eliminateCount;
        private float GetSurviveTime() => Time.time - _startTime;
        private void AddEliminateCount() => _eliminateCount++;
    }
}
