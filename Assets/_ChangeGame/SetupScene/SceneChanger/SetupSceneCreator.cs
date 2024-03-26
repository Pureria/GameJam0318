using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChangeGame.Scene
{
    public class SetupSceneCreator
    {
        [RuntimeInitializeOnLoadMethod]
        private static void CreateSetupScene()
        {
            string sceneName = "SetupScene";
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}