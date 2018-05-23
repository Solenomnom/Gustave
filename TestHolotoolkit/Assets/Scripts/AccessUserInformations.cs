using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using HoloToolkit.Unity.InputModule;
/*
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


public class AccessUserInformations : MonoBehaviour, IInputClickHandler
{
    UserInformations userInformations;
   // Tokens tokens;

    void Start()
    {
       // tokens = UserTokens.tokens;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("ça passe par là");
        StartCoroutine(sendRequest());
        Debug.Log("et iciiiiiiiiiii c'est bon " + userInformations.username);
        StartCoroutine(UserRecipe());

    }

    void initUserInformations()
    {
        Debug.Log("Username");
        Debug.Log(userInformations.username + "debug intermediaire");
        GameObject.Find("Text").GetComponent<Text>().text = "Bienvenue " + userInformations.username;

    }

    public UserInformations getUserInformationsFromJson(string jsonString)
    {
        return JsonUtility.FromJson<UserInformations>(jsonString);
    }

    IEnumerator sendRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://api.gustave.pro/user/infos"))
        {
            Debug.Log(UserTokens.tokens.access_token + "+++++++++++");
            www.SetRequestHeader("Authorization", "Bearer " + UserTokens.tokens.access_token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text); // print body response et gérer les erreurs
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
                userInformations = getUserInformationsFromJson(www.downloadHandler.text);
                // initUserInformations(); simple affichage
            }
        }
    }

    /*
    public void StartUserRecipe()
    {
    }
    
    public UserRecipe getRecipeIdFromJson(string jsonString)
    {
        return JsonUtility.FromJson<UserRecipe>(jsonString);
    }

    public IEnumerator GetRecipe(string id)
    {
        Debug.Log("je passe iciiiiiiiiiiiiiiiiiiiii");
        using (UnityWebRequest www = UnityWebRequest.Get("https://api.gustave.pro/recipe/info?id=" + id))
        {
            www.SetRequestHeader("Authorization", "Bearer " + UserTokens.tokens.access_token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("je passe icaaaaaaaaaaaaaaaaaaaa");
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text); // print body response
            }
            else
            {
                Debug.Log("Form upload complete! again");
                Debug.Log("on obtient >>>>>>" + www.downloadHandler.text);
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
                Debug.Log("c'es un miracle");
                Debug.Log("Form upload complete!");
                Debug.Log("{\"Items\":" + www.downloadHandler.text + "}");
                UserRecipe[] userRecipe = JsonHelper.FromJson<UserRecipe>("{\"Items\":" + www.downloadHandler.text + "}");

                for (int i = 0; i < userRecipe.Length; i++)
                {
                    Debug.Log("//////////" + userRecipe[i].RecipeId);
                    StartCoroutine(GetRecipe(userRecipe[i].RecipeId));
                }
                // call GetRecipe for each Recipe ID from the www.downloadHandler.text
                // GameObject.Find("Text").GetComponent<Text>().text = www.downloadHandler.text;
            }
        }
    }

    public void RefreshToken()
    {
        StartCoroutine(RefreshTokenRequest("refresh_token", UserTokens.tokens.refresh_token));
    }

    public IEnumerator RefreshTokenRequest(string grant_type, string token)
    {
        WWWForm form = new WWWForm();
        form.AddField("grant_type", grant_type);
        form.AddField("refresh_token", token); // here token = refresh_token

        using (UnityWebRequest www = UnityWebRequest.Post("https://api.gustave.pro/oauth2/token", form))
        {
            // Adding in the header this -> ("Authorization", "Basic base64(client_id:client_secret)")
            // Each request for the user must have this kind of header with different key
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("923ab2dc-c291-4a15-b9db-2d3b9c84cb9c:3JIzAHCKpoDtrVC1GoOHahdxrBAiKQeLtEbutxtnOg");
            www.SetRequestHeader("Authorization", "Basic " + System.Convert.ToBase64String(plainTextBytes));
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text); // print body response
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text); // parse for having the new acces_token and refresh_token
            }
        }
    }

}

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
}*/