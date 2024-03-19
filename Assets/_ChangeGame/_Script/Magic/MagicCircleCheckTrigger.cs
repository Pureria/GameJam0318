using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorePackage;
using UnityEngine.Playables;

namespace ChangeGame.Magic
{
    public class MagicCircleCheckTrigger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private float _damageAmount = 30.0f;
        
        [Header("Check Info")]
        [SerializeField] private float _checkRadius = 0.5f;
        [SerializeField] private Transform _checkTransform;
        
        /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player") return;

            Core tCore = other.gameObject.GetComponentInChildren<Core>();
            if(tCore == null) return;
            if (tCore.GetCoreComponentBool(out Damage damage))
            {
                damage.AddDamage(_damageAmount);
            }
        }
        */

        private void FixedUpdate()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_checkTransform.position, _checkRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Player") continue;
                Core tCore = hitCollider.gameObject.GetComponentInChildren<Core>();
                if(tCore == null) continue;
                if (tCore.GetCoreComponentBool(out Damage damage))
                {
                    damage.AddDamage(_damageAmount);
                }
            }
        }

        private void OnDrawGizmos()
        {
            //円を描画
            Gizmos.color = new Color(0, 0, 255, 0.5f);
            Gizmos.DrawSphere(_checkTransform.position, _checkRadius);
        }

        private void EndTimeline(PlayableDirector director)
        {
            Destroy(this.gameObject);
        }

        private void OnEnable()
        {
            _playableDirector.stopped += EndTimeline;
        }

        private void OnDisable()
        {
            _playableDirector.stopped -= EndTimeline;
        }
    }
}
