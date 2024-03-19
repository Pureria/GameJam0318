using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool _bStart;   //GameScene�ɑJ�ڂł��邩�ǂ���

    [SerializeField]
    private Fade _fade;
    [SerializeField]
    private string _nextSceneName = "TitleTransitionTestScene";  //�J�ڌ�̃V�[����

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
        SceneManager.LoadScene(_nextSceneName);
    }

    /// <summary>
    /// TitleScene�̃{�^�����N���b�N�����Ƃ��Ƀt�F�[�h�A�E�g���ăV�[���J�ڂ���
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
