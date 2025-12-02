using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    private bool isFirstPerson = true;

    void Start()
    {
        // Start with first person inactive
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        isFirstPerson = !isFirstPerson;

        firstPersonCamera.enabled = isFirstPerson;
        thirdPersonCamera.enabled = !isFirstPerson;
    }
}

