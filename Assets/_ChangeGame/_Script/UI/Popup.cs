using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] protected Animator _anim;
        [SerializeField] protected AudioSource _seSource;
        [SerializeField] protected AudioClip _openSE;
        [SerializeField] protected AudioClip _closeSE;

        public virtual void Open()
        {
            _anim.SetTrigger("open");
            _seSource.PlayOneShot(_openSE);
        }

        public virtual void Close()
        {
            _anim.SetTrigger("close");
            _seSource.PlayOneShot(_closeSE);
        }
    }
}
