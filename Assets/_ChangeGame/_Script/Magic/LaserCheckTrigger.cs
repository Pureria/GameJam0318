using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using CorePackage;

namespace ChangeGame.Magic
{
    public class LaserCheckTrigger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private float _damageAmount = 30.0f;
        
        [Header("Check Info")]
        [SerializeField] private float _checkRadius = 0.5f;
        [SerializeField] private List<Transform> _checkTransforms = new List<Transform>();

        [SerializeField] private bool _isNowAttack;
        
        private List<Collider> _hitColliders = new List<Collider>();

        private void Start()
        {
            _isNowAttack = false;
        }
        
        private void FixedUpdate()
        {
            if (!_isNowAttack) return;
            /*
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
            */
            
            //_checkTransformsのすべてのポジションでPhysics.OverlapSphereを実行し範囲内のすべてのColliderを取得する（重複しないようにする）
            _hitColliders.Clear();
            foreach (var checkTransform in _checkTransforms)
            {
                Collider[] colliders = Physics.OverlapSphere(checkTransform.position, _checkRadius);
                foreach (var collider in colliders)
                {
                    if (!_hitColliders.Contains(collider))
                    {
                        _hitColliders.Add(collider);
                    }
                }
            }

            foreach (var hitCollider in _hitColliders)
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
            if (!_isNowAttack) return;
            
            //円を描画
            Gizmos.color = new Color(0, 0, 255, 0.5f);
            //Gizmos.DrawSphere(_checkTransform.position, _checkRadius);
            foreach (var checkTransform in _checkTransforms)
            {
                Gizmos.DrawSphere(checkTransform.position, _checkRadius);
            }
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
        
        public void SetIsAttack(bool isAttack)
        {
            _isNowAttack = isAttack;
        }
    }
}
