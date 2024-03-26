using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChangeGame.Scene;
using ChangeGame.UI;

namespace ChangeGame.Manager
{
    public class GameManager : MonoBehaviour
    {
        //[SerializeField] private Fade _fade;
        [SerializeField] private GameManagerSO _gameManagerSO;
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private OptionPopup _optionPopup;
        
        [Header("Scene Change Info")]
        [SerializeField] private int _nextSceneIndex;  //遷移後のシーン番号
        [SerializeField] private SceneChangeEffect _sceneChangeEffect = SceneChangeEffect.Fade;
        [SerializeField] private float _fadeTime;
        
        private int _eliminateCount;
        private float _startTime;
        private float _gameTime;
        private bool _isGame;
        private bool _isGameEnd;
        private bool _isGamePause;
        private Transform _playerTransform;
        
        private void Start()
        {
            _scoreSO.Score = 0;
            _isGame = false;
            _isGameEnd = false;
            _isGamePause = false;
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
            _gameTime += Time.deltaTime;
            _scoreSO.SurviveTime = GetSurviveTime();
            _scoreSO.EliminateCount = GetEliminateCount();
            
            //Pを押したらタイムスケールを0にする
            if (UnityEngine.Input.GetKeyDown(KeyCode.P))
            {
                CheckPause();
            }
        }

        private void OnEnable()
        {
            _gameManagerSO.OnPlayerDeadEvent += GameEnd;
            _gameManagerSO.OnGetEliminateCountEvent += GetEliminateCount;
            _gameManagerSO.OnGetSurviveTimeEvent += GetSurviveTime;
            _gameManagerSO.OnAddEliminateCountEvent += AddEliminateCount;
            _gameManagerSO.OnSetPlayerTransformEvent += SetPlayerTransform;
            _gameManagerSO.OnGetPlayerTransformEvent += GetPlayerTransform;
            
            SetCursol(true);
        }

        private void OnDisable()
        {
            _gameManagerSO.OnPlayerDeadEvent -= GameEnd;
            _gameManagerSO.OnGetEliminateCountEvent -= GetEliminateCount;
            _gameManagerSO.OnGetSurviveTimeEvent -= GetSurviveTime;
            _gameManagerSO.OnAddEliminateCountEvent -= AddEliminateCount;
            _gameManagerSO.OnSetPlayerTransformEvent -= SetPlayerTransform;
            _gameManagerSO.OnGetPlayerTransformEvent -= GetPlayerTransform;
            
            SetCursol(false);
        }

        private void SetCursol(bool lockCursol)
        {
            if (!lockCursol)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void GameStart()
        {
            _gameManagerSO.OnGameStartEvent?.Invoke();
            _eliminateCount = 0;
            _startTime = Time.time;
            _isGame = true;
            _gameTime = 0;
            _isGameEnd = false;
            _isGamePause = false;
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
        private float GetSurviveTime() => _gameTime;
        private void AddEliminateCount() => _eliminateCount++;

        public void CheckPause()
        {
            if (_isGamePause)
            {
                Time.timeScale = 1;
                _isGamePause = false;
                _optionPopup.Close();
                SetCursol(true);
            }
            else
            {
                Time.timeScale = 0;
                _isGamePause = true;
                _optionPopup.Open();
                SetCursol(false);
            }
        }
    }
}
