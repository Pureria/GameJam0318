using System.Collections;
using System.Collections.Generic;
using ChangeGame.Scene;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool _bStart;   //GameScene�ɑJ�ڂł��邩�ǂ���

    /*
    [SerializeField]
    private Fade _fade;
    [SerializeField]
    private string _nextSceneName = "TitleTransitionTestScene";  //�J�ڌ�̃V�[����
    */
    
    [SerializeField] private int _nextSceneIndex;  //�J�ڌ�̃V�[���ԍ�
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
    /// �t�F�[�h�A�E�g���GameScene�ɑJ�ڂł���悤�ɂȂ�
    /// </summary>
    private void _TitleStart()
    {
        _bStart = true;
    }

    /// <summary>
    /// �J�ڌ��Scene�w��
    /// </summary>
    private void _ChangeScene()
    {
        //SceneManager.LoadScene(_nextSceneName);
    }

    /// <summary>
    /// TitleScene�̃{�^�����N���b�N�����Ƃ��Ƀt�F�[�h�A�E�g���ăV�[���J�ڂ���
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
