using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using HoloToolkit.Unity.InputModule;

	
public class ServerConnect : MonoBehaviour, IInputClickHandler
{
	public InputField emailField;
	public InputField usernameField;
	public InputField passwordField;
	public GameObject errorMessage;
	public GameObject LogInMenu;

	
    void Start()
    {
        //StartCoroutine(Upload());
    }
    /*
    public IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", "gustave.chief@outlook.com");
		form.AddField("password", "Gustave44");
		form.AddField("username", "Gustave");

        using (UnityWebRequest www = UnityWebRequest.Post("https://api.gustave.pro/auth/signup", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else	
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    */
    public void OnInputClicked(InputClickedEventData eventData)
    {
        StartCoroutine(SignInRequest(emailField.text, passwordField.text, usernameField.text));
    }
	
	public IEnumerator SignInRequest(string email, string password, string userName)
	{
		WWWForm form = new WWWForm();
        form.AddField("email", "romain.test@lol.com");
		form.AddField("password", "bibica");
		form.AddField("username", "test");

        GameObject parent = GameObject.Find("Menu Manager");

        using (UnityWebRequest www = UnityWebRequest.Post("https://api.gustave.pro/auth/signup", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("c'est pas bon"); // gestion d'erreur à revoir

                errorMessage.SetActive(true);
                Debug.Log(www.error);
                find_object.FindObject(parent, "Error").SetActive(true);
                find_object.FindObject(parent, "EmailTaken").SetActive(true);
            }
            else
            {
                find_object.FindObject(parent, "Log In Menu").SetActive(true);
                find_object.FindObject(parent, "Sign In Menu").SetActive(false);
                Debug.Log("Form upload complete!");
            }
        }
	}
}