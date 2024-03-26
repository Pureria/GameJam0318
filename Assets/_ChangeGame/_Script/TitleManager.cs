using System.Collections;
using System.Collections.Generic;
using ChangeGame.Scene;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool _bStart;   //GameSceneに遷移できるかどうか

    /*
    [SerializeField]
    private Fade _fade;
    [SerializeField]
    private string _nextSceneName = "TitleTransitionTestScene";  //遷移後のシーン名
    */
    
    [SerializeField] private int _nextSceneIndex;  //遷移後のシーン番号
    [SerializeField] private SceneChangeEffect _sceneChangeEffect = SceneChangeEffect.Fade;
    [SerializeField] private float _fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        _bStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// フェードアウト後にGameSceneに遷移できるようになる
    /// </summary>
    private void _TitleStart()
    {
        _bStart = true;
    }

    /// <summary>
    /// 遷移後のScene指定
    /// </summary>
    private void _ChangeScene()
    {
        //SceneManager.LoadScene(_nextSceneName);
    }

    /// <summary>
    /// TitleSceneのボタンをクリックしたときにフェードアウトしてシーン遷移する
    /// </summary>
    public void OnButtonClick()
    {
        /*
        if (_bStart)
        {
            _fade.FadeStart(_ChangeScene);
            _bStart = false;
        }
        */

        SceneManager.ChangeSceneWait(_nextSceneIndex, _sceneChangeEffect, _fadeTime);
    }

}
