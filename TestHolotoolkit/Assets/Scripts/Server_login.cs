﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Tokens
{
    public string access_token;
    public string refresh_token;
    public string token_type;
}

public class UserInformations
{
    protected int id;
    protected string email;
    public string username;
    protected string password;
    protected string token;
    protected string createdAt;
    protected string updatedAt;
}

[System.Serializable]
public class UserRecipe
{
    protected int id;
    protected string createdAt;
    protected string updatedAt;
    protected int UserId;
    public string RecipeId;
}

public class Server_login : MonoBehaviour, IInputClickHandler
{
    UserInformations userInformations;
    public Tokens tokens;
    public InputField emailField;
    public InputField passwordField;

    // Use this for initialization
    void Start()
    {

    }

    public Tokens getTokensFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Tokens>(jsonString);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        StartCoroutine(LogInRequest("password", emailField.text, passwordField.text));
    }

    // GameObject parent = GameObject.Find("Menu Manager");

    public IEnumerator LogInRequest(string grant_type, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("grant_type", grant_type);
        form.AddField("username", "romain.chateigner@epitech.eu"); // pour les tests plus rapides
        form.AddField("password", "bibica25*");

        using (UnityWebRequest www = UnityWebRequest.Post("https://api.gustave.pro/oauth2/token", form))
        {
            // Adding in the header this -> ("Authorization", "Basic base64(client_id:client_secret)")
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("923ab2dc-c291-4a15-b9db-2d3b9c84cb9c:3JIzAHCKpoDtrVC1GoOHahdxrBAiKQeLtEbutxtnOg");
            www.SetRequestHeader("Authorization", "Basic " + System.Convert.ToBase64String(plainTextBytes));
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text); // gestion des popups d'erreurs à faire dès que la phase de test est finie
               /* find_object.FindObject(parent, "Error Popup").SetActive(true);
                if (email == "")
                {
                    find_object.FindObject(parent, "Missing Email").SetActive(true);
                }
                else if (password == "")
                {
                    find_object.FindObject(parent, "Missing Password").SetActive(true);
                }*/
            }   
            else
            {
                Debug.Log("Form upload complete! LogIn");
                tokens = getTokensFromJson(www.downloadHandler.text);
                UserTokens.tokens = tokens;
                Debug.Log("Access token >>>>>>>>>>>>>>>>" + UserTokens.tokens.access_token + "<<<<<<<<<<<<<<<<<<<<");

                StartCoroutine(GetUserInfos());
            }
        }
    }

    public UserInformations getUserInformationsFromJson(string jsonString)
    {
        return JsonUtility.FromJson<UserInformations>(jsonString);
    }

    IEnumerator GetUserInfos()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://api.gustave.pro/user/infos"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + UserTokens.tokens.access_token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Form upload complete! UserInfos");
                Debug.Log(www.downloadHandler.text);
                userInformations = getUserInformationsFromJson(www.downloadHandler.text);
                StartCoroutine(UserRecipe());
            }
        }
    }

    public IEnumerator GetRecipe(string id)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://api.gustave.pro/recipe/info?id=" + id))
        {
            www.SetRequestHeader("Authorization", "Bearer " + UserTokens.tokens.access_token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Here is the file >>>>>>" + www.downloadHandler.text);
                System.IO.File.WriteAllText(@"Assets\Resources\JsonRecipes\" + id + "_recipe.json", www.downloadHandler.text);
            }
        }
    }

    public IEnumerator UserRecipe()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://api.gustave.pro/user/recipes"))
        {
            www.SetRequestHeader("Authorization", "Bearer " + UserTokens.tokens.access_token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text); // print body response
            }
            else
            {
                Debug.Log("Form upload complete! UserRecipe");
                UserRecipe[] userRecipe = JsonHelper.FromJson<UserRecipe>("{\"Items\":" + www.downloadHandler.text + "}");

                for (int i = 0; i < userRecipe.Length; i++)
                {
                    Debug.Log("RecipeId numéro //////////" + userRecipe[i].RecipeId);
                    StartCoroutine(GetRecipe(userRecipe[i].RecipeId));
                }
                yield return new WaitForSeconds(5);
                ClientManager.CM.setUserInfo(userInformations);
                ClientManager.CM.LoadMenuScene();
            }
        }
    }

}

// Here is a class for JSon serializer and stuff like that

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}