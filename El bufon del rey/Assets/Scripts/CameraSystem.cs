using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private JokesManager jokesManager;

    private float camSpeed = 1f;
    private float minFieldOfView = 20f;
    private float maxFieldOfView = 60f;
    private float fieldOfView;
    public float verticalSpeed = 0.1f;
    private void Start()
    {
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
        fieldOfView = virtualCamera.m_Lens.FieldOfView;
    }
    private void Update()
    {
        //MakeTransition();
    }

    public void MakeTransition()
    {
        float fieldOfVIewIncreaseAmount = 5f;
        if (Input.mouseScrollDelta.y > 0) {
            fieldOfView -= fieldOfVIewIncreaseAmount;
        }if (Input.mouseScrollDelta.y < 0) {
            fieldOfView += fieldOfVIewIncreaseAmount;
        }

        fieldOfView = Mathf.Clamp(fieldOfView, minFieldOfView, maxFieldOfView);

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, fieldOfView, camSpeed * Time.deltaTime); 
    }
    public void Zoom()
    {
        StartCoroutine(StartZoom());
    }

    IEnumerator StartZoom()
    {
        float initialFieldOfView = virtualCamera.m_Lens.FieldOfView;
        Vector3 initialVirtualCamera = virtualCamera.m_Follow.position;
        float initialVirtualCameraY = initialVirtualCamera.y;
        jokesManager.ChangeVisibleButtons();
        yield return new WaitForSeconds(0.1f);
        float time = 1.5f;
        Debug.Log("before enter the while");
        float currentTime = 0f;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(initialFieldOfView, minFieldOfView, currentTime/time);
            initialVirtualCameraY = Mathf.Lerp(initialVirtualCameraY, 4.1f, (currentTime/time)*verticalSpeed);
            virtualCamera.m_Follow.position = new Vector3(initialVirtualCamera.x, initialVirtualCameraY, initialVirtualCamera.z);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("finished while");

        yield return new WaitForSeconds(3.1f);

        currentTime = 0f;
        Debug.Log("before enter the second while");
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(minFieldOfView, initialFieldOfView, currentTime / time);
            initialVirtualCameraY = Mathf.Lerp(4.1f, initialVirtualCamera.y, currentTime / time);
            virtualCamera.m_Follow.position = new Vector3(initialVirtualCamera.x, initialVirtualCameraY, initialVirtualCamera.z);
            yield return new WaitForEndOfFrame();
        }
        jokesManager.ChangeVisibleButtons();
        jokesManager.UpdateButtons();
        Debug.Log("finished second while");
    }
}
