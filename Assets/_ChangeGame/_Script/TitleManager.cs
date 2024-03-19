using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private bool _bStart;
    private Fade _fade;

    // Start is called before the first frame update
    void Start()
    {
        _bStart = false;
        _fade = GetComponent<Fade>();
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

    public void TransitionButton()
    {
        Debug.Log("‘JˆÚ‚Å‚«‚½‚æI");
        SceneManager.LoadScene("TitleTransitionTestScene");
    }

}
