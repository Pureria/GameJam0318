using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool _bStart;

    [SerializeField]
    private Fade _fade;

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

    private void _TitleStart()
    {
        _bStart = true;
    }

    private void _ChangeScene()
    {
        SceneManager.LoadScene("TitleTransitionTestScene");
    }

    public void OnButtonClick()
    {
        if (_bStart)
        {
            _fade.FadeStart(_ChangeScene);
            _bStart = false;
        }
    }

}
