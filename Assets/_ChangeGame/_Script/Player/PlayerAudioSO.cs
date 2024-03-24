using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Player
{
    [CreateAssetMenu(fileName = "PlayerAudioSO", menuName = "ChangeGame/Player/PlayerAudioSO")]
    public class PlayerAudioSO : ScriptableObject
    {
        public AudioClip DamageSE;
        public AudioClip DeadSE;
        public AudioClip ChangeNormalSE;
        public AudioClip ChangeSuperSE;
        public AudioClip CountDownLow;
        public AudioClip CountDownHigh;
        public AudioClip Avoid;

        [HideInInspector] public AudioSource DamageSource;
        [HideInInspector] public AudioSource PlayerModeSource;
    }
}
