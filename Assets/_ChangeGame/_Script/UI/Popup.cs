using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Animator _anim;

        public void Open()
        {
            _anim.SetTrigger("open");
        }

        public void Close()
        {
            _anim.SetTrigger("close");
        }
    }
}
