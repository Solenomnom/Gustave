using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class DisconnectButton : MonoBehaviour, IInputClickHandler
{
    GameObject camera;
    GameObject clientManager;
    GameObject inputManager;

    public void OnInputClicked(InputClickedEventData eventData)
    {

        //supprimer tous les fichiers du dossier
        Destroy(camera);
        Destroy(clientManager);
        Destroy(inputManager);
        ClientManager.CM.setUserInfo(null);
        ClientManager.CM.LoadConnectMenuScene();
    }

    // Use this for initialization
    void Start () {
        camera = GameObject.Find("MixedRealityCameraParent");
        clientManager = GameObject.Find("ClientManager");
        inputManager = GameObject.Find("InputManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
