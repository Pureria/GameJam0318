using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Manager
{
    [CreateAssetMenu(fileName = "GameManagerSO", menuName = "ChangeGame/Manager/GameManagerSO")]
    public class GameManagerSO : ScriptableObject
    {
        public Action OnGameStartEvent; //ゲーム開始時にマネージャーから呼び出される
        public Action OnGameEndEvent;   //ゲーム終了時にマネージャーから呼び出される
        public Action OnAddEliminateCountEvent; //エリミネート数を加算する
        public Action OnPlayerDeadEvent;    //プレイヤーが死亡した時に呼び出される
        public Action<Transform> OnSetPlayerTransformEvent; //プレイヤーのTransformを設定する
        public Func<int> OnGetEliminateCountEvent;  //エリミネート数を取得する
        public Func<float> OnGetSurviveTimeEvent;   //生存時間を取得する
        public Func<Transform> OnGetPlayerTransformEvent; //プレイヤーのTransformを取得する
    }
}
