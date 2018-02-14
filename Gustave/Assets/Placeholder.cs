using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Placeholder : MonoBehaviour, IInputClickHandler
{
    public Transform window;

    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(
          this.gameObject);
    }
    public void OnInputClicked(InputEventData eventData)
    {
        window.gameObject.transform.position =
          GazeManager.Instance.GazeOrigin +
          GazeManager.Instance.GazeNormal * 1.5f;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        throw new NotImplementedException();
    }
}