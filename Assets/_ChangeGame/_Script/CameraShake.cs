using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShape : MonoBehaviour
{
    //�v���C���[���U�������Ƃ��ɃJ������h�炷
     
    

    private void Shape()
    {
        CinemachineImpulseSource impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();
    }


}
