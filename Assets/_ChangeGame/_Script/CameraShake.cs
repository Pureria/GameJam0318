using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShape : MonoBehaviour
{
    //プレイヤーが攻撃したときにカメラを揺らす
     
    

    private void Shape()
    {
        CinemachineImpulseSource impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();
    }


}
