using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject _prefabRecipeWindow;

    List<RecipeWindow> _recipeWindows = null;
    List<string> _jsonFilePathList = null;
    JsonRecipeReader _jsonRecipeReader = new JsonRecipeReader();
    List<GameObject> _recipeWindowsGameobjectList = new List<GameObject>();
    int _windowNb = 0;
    int _jsonPathStartPositionInList = 0;
    int _jsonPathCurrentPositionInList = 0;
    int _windowMax = 4;
    bool _multiplePages = false;
    int[] x_position = new int[] { 0, 400, 0, 400 };
    int[] y_position = new int[] { 0, 0, -250, -250 };

    // Use this for initialization
    void Start () {
        print("start ---");
        _jsonFilePathList = _jsonRecipeReader.getJsonFilePaths();
        createRecipeWindowsList();
        if (_jsonFilePathList.Count > 4)
        {
            _multiplePages = true;
            //  create Prev and Next Arrows !
        }
    }

   
	// Update is called once per frame
	void Update () {
		
	}

    GameObject createRecipeWindow(string json_path)
    {
        GameObject recipe_window = null;
        
        recipe_window = Instantiate(_prefabRecipeWindow);
        recipe_window.transform.SetParent(gameObject.transform.GetChild(0).transform, false);
        recipe_window.transform.localPosition += new Vector3(x_position[_windowNb], y_position[_windowNb], 0);
        recipe_window.transform.localScale = new Vector3(1, 1, 1);
        
        recipe_window.GetComponent<RecipeWindow>().setInfo(_jsonRecipeReader.getFastRecipeTitle(json_path));
        return recipe_window;
    }

    void createRecipeWindowsList()
    {
        //print(window_nb);
        print("max = " + _windowMax.ToString());
        print("size = " + _jsonFilePathList.Count.ToString());
        for(; (_windowNb < _windowMax) && (_windowNb < _jsonFilePathList.Count); _windowNb++) {
            print(_jsonFilePathList[_jsonPathCurrentPositionInList]); 
           _recipeWindowsGameobjectList.Add(createRecipeWindow(_jsonFilePathList[_jsonPathCurrentPositionInList]));
            _jsonPathCurrentPositionInList++;
        }
    }
}
