using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Manager
{
    [CreateAssetMenu(fileName = "ScoreSO", menuName = "ChangeGame/Manager/ScoreSO")]
    public class ScoreSO : ScriptableObject
    {
        public float SurviveTime;
        public float EliminateCount;
        public float Score;
    }
}
