using System.Collections;
using System.Collections.Generic;
using ChangeGame.Manager;
using TMPro;
using UnityEngine;

namespace ChangeGame.UI
{
    public class GameScoreBoard : MonoBehaviour
    {
        [SerializeField] private ScoreSO _scoreSO;
        [SerializeField] private TextMeshProUGUI _elimiText;
        [SerializeField] private TextMeshProUGUI _timeText;

        private void Update()
        {
            _elimiText.text = _scoreSO.EliminateCount.ToString();
            _timeText.text = _scoreSO.SurviveTime.ToString("F2");
        }
    }
}
