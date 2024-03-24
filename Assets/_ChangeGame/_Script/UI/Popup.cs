using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private AudioSource _seSource;
        [SerializeField] private AudioClip _openSE;
        [SerializeField] private AudioClip _closeSE;

        public void Open()
        {
            _anim.SetTrigger("open");
            _seSource.PlayOneShot(_openSE);
        }

        public void Close()
        {
            _anim.SetTrigger("close");
            _seSource.PlayOneShot(_closeSE);
        }
    }
}
