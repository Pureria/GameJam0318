using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorePackage
{
    public class Movement : CoreComponent
    {
        private Rigidbody _myRB;

        protected override void Awake()
        {
            base.Awake();
            if (!transform.root.TryGetComponent<Rigidbody>(out _myRB))
            {
                Debug.LogError("Rigidbodyが親オブジェクトに存在しません。");
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        
        public void Move(Vector3 direction, float speed)
        {
            Vector3 velo = direction;
            velo.y = 0;
            velo = velo.normalized * speed;
            velo.y = _myRB.velocity.y;
            _myRB.velocity = velo;
            
            //Quaternion targetRotation = Quaternion.LookRotation(_myRB.velocity);
            //transform.root.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // 滑らかな回転
            //上の処理をz軸には回転しないように
            Quaternion targetRotation = Quaternion.LookRotation(_myRB.velocity);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.root.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // 滑らかな回転
        }

        public void Stop()
        {
            _myRB.velocity = Vector3.zero;
        }

        public void Jump(float jumpPower)
        {
            Vector3 velo = _myRB.velocity;
            velo.y = jumpPower;
            _myRB.velocity = velo;
        }

        public void AddVelocity(Vector3 addVelo)
        {
            _myRB.velocity += addVelo;
        }
        
        public void SetVelocity(Vector3 setVelo)
        {
            _myRB.velocity = setVelo;
        }
    }
}
