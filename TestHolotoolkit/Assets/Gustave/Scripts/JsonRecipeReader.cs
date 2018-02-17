using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class JsonRecipeReader : MonoBehaviour{
    private JSONNode _recette;

    // Use this for initialization

    public List<string> getJsonFilePaths()
    {
        print("> getJsonFilePaths");
        DirectoryInfo levelDirectoryPath = new DirectoryInfo(Application.dataPath + "./Resources/JsonRecipes");
        FileInfo[] fileInfo = levelDirectoryPath.GetFiles("*.*");
        List<string> recipe_path = new List<string>();
        
        foreach (FileInfo file in fileInfo)
        {
            print(file.Name);
            if (file.Extension == ".txt")
            {
                int end_position_extension = file.Name.Length - 4;
                recipe_path.Add("JsonRecipes/" + file.Name.Substring(0, end_position_extension));

            }
        }
        print(recipe_path.Count);
        return recipe_path;
    }

    public string getFastRecipeTitle(string path)
    {
        TextAsset json_file = Resources.Load(path) as TextAsset;
        return JSON.Parse(json_file.text)["description"]["name"].ToString().Trim('"');
    }

    public void setJsonRecipe(string json_string)
    {
        _recette  = JSON.Parse(json_string);
    }

    public string getCurrentRecipeTitle()
    {
        return _recette["description"]["name"].ToString().Trim('"');
    }

    public int getCurrentRecipeNbSteps()
    {
        return _recette["steps"].Count;
    }

    public string getCurrentRecipeStepText(int step_nb)
    {
        print(_recette["steps"][step_nb]["text"].ToString().Trim('"'));
        return _recette["steps"][step_nb]["text"].ToString().Trim('"');
    }

    public int getCurrentRecipeNbIngredient()
    {
        return _recette["ingredients"].Count;
    }

    public string getCurrentRecipeIngredientName(int ingredient_nb)
    {
        return _recette["ingredients"][ingredient_nb]["name"].ToString().Trim('"');
    }

    public string getCurrentRecipeStepImage(int step_nb)
    {
        return _recette["steps"][step_nb]["image"].ToString().Trim('"');
    }

    public string getCurrentRecipeStepTimerFlag(int step_nb)
    {
        return _recette["steps"][step_nb]["timer_flag"].ToString().Trim('"');
    }

    public string getCurrentRecipeStepVideoFlag(int step_nb)
    {
        return _recette["steps"][step_nb]["video_flag"].ToString().Trim('"');

    }

    public string getCurrentRecipeStepVideoPath(int step_nb)
    {
        return _recette["steps"][step_nb]["video"][0].ToString().Trim('"');
    }

    public int getCurrentRecipeStepTimer(int step_nb)
    {
        return _recette["steps"][step_nb]["timer"]["time"].AsInt;
    }


}
