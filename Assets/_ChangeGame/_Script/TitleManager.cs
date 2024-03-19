using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool _bStart;   //GameSceneに遷移できるかどうか

    [SerializeField]
    private Fade _fade;
    [SerializeField]
    private string _nextSceneName = "TitleTransitionTestScene";  //遷移後のシーン名

    // Start is called before the first frame update
    void Start()
    {
        _bStart = false;
        _fade.FadeStart(_TitleStart);
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
        SceneManager.LoadScene(_nextSceneName);
    }

    /// <summary>
    /// TitleSceneのボタンをクリックしたときにフェードアウトしてシーン遷移する
    /// </summary>
    public void OnButtonClick()
    {
        if (_bStart)
        {
            _fade.FadeStart(_ChangeScene);
            _bStart = false;
        }
    }

}
