using UnityEngine;
using Cinemachine;

// Credits to samyam's Youtube video: Cinemachine First Person Controller w/ Input System - Unity Tutorial - https://www.youtube.com/watch?v=5n_hmqHdijM
public class CinemachinePOVExtension : CinemachineExtension
{
    [Range(0.01f, 50f)]
    [SerializeField] float verticalSensitivity = 1f;

    [Range(0.01f, 50f)]
    [SerializeField] float horizontalSensitivity = 1f;

    [Range(0f, 360f)]
    [SerializeField] float clampAngle = 80f;

    InputManager inputManager;
    Vector3 startingRotation;

    [SerializeField] Transform pickupTarget;
    Camera mainCamera;

    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        mainCamera = Camera.main;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (!vcam.Follow)
        {
            return;
        }

        if (stage != CinemachineCore.Stage.Aim)
        {
            return;
        }

        if (startingRotation == null)
        {
            startingRotation = transform.localRotation.eulerAngles;
        }
        Vector2 lookInput = inputManager.GetLookValue();
        startingRotation.x += lookInput.x * Time.deltaTime * verticalSensitivity;
        startingRotation.y += lookInput.y * Time.deltaTime * horizontalSensitivity;

        startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);

        state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

        CenterPickupTarget();
    }

    public float VerticalSensitivity { get { return verticalSensitivity; } set { verticalSensitivity = value; } }
    public float HorizontalSensitivity { get { return horizontalSensitivity; } set { horizontalSensitivity = value; } }

    // Asked ChatGPT. Prompt: "i'm using Cinemachine to have a POV camera using a custom CinemachineExtension to overrider PostPipelineStageCallback to change the RawOrientation of the virtual camera. How do I position a game object to be in the center of the camera view at all times"
    void CenterPickupTarget()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(pickupTarget.position);

        pickupTarget.position = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2f, mainCamera.pixelHeight / 2f, screenPos.z));
    }
}
