using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private float camSpeed = 5f;
    private float minFieldOfView = 30f;
    private float maxFieldOfView = 60f;
    private float fieldOfView;
    private void Start()
    {
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
        fieldOfView = virtualCamera.m_Lens.FieldOfView;
    }
    private void Update()
    {
        MakeTransition();
    }

    public void MakeTransition()
    {
        float 
        if (Input.mouseScrollDelta.y > 0) { 
            fieldOfView -= 
        }
            fieldOfView = fieldOfView * camSpeed * Time.deltaTime;
            fieldOfView = Mathf.Clamp(fieldOfView, minFieldOfView, maxFieldOfView);
            virtualCamera.m_Lens.FieldOfView = fieldOfView;
        

    }
}
