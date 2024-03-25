using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Scene
{
    public abstract class SceneChangerBase : MonoBehaviour
    {
        protected SceneChangeEffect _sceneChangeEffect;

        private void Awake()
        {
            Initialize();
        }

        protected abstract void Initialize();
    
        public virtual bool InSCEffect(float scTime, SceneChangeEffect effect)
        {
            if (_sceneChangeEffect != effect) return false;
            return true;
        }
        
        public virtual bool OutSCEffect(float scTime, SceneChangeEffect effect)
        {
            if (_sceneChangeEffect != effect) return false;
            return true;
        }
    }
}