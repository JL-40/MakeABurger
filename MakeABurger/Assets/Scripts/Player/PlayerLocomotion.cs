using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

// Credits to samyam's Youtube video: Cinemachine First Person Controller w/ Input System - Unity Tutorial - https://www.youtube.com/watch?v=5n_hmqHdijM
public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    CharacterController controller;
    Vector3 playerVelocity;

    Transform cameraTransform;

    [SerializeField] float playerSpeed = 2.0f;
    float gravityValue = -9.81f;

    EventInstance footStepEventInstance;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;

        footStepEventInstance = AudioManager.Instance.CreateEventInstance(FModEvents.Instance.footsteps, gameObject.transform);
    }

    void Update()
    {
        Move();

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Move()
    {
        Vector2 moveDirection = inputManager.GetMovementValue();
        Vector3 move = new Vector3(moveDirection.x, 0f, moveDirection.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * (Time.deltaTime * playerSpeed));

        UpdateFootStepAudio(move);
    }

    void UpdateFootStepAudio(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            PLAYBACK_STATE playbackState;
            footStepEventInstance.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                footStepEventInstance.start();
            }

        }
        else
        {
            footStepEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}
