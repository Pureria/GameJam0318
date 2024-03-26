using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.UI
{
    public class OptionPopup : Popup
    {
        private void Start()
        {
            _anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        
        public override void Open()
        {
            base.Open();
        }
        
        public override void Close()
        {
            base.Close();
        }
    }
}
