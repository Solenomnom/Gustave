using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

    // Use this for initialization
    
    public Square square;
    public Recette recette;
    public Text stepDescribe;
    public Square[] squareArray;
    public GameObject help;
    public Mesh squareMesh;
    public Mesh tubeMesh;

    void Start () {
        /*   GameObject obj = new GameObject("sqr0");
           obj.AddComponent<RectTransform>();
           RectTransform rt = obj.GetComponent<RectTransform>();
           rt.sizeDelta = new Vector2(100, 100);*/
        squareArray = new Square[recette.steps.Length];
        UpdateHud();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
            NextStep();

        if (Input.GetKeyDown("left"))
            PrevStep();

    }

    void UpdateHud()
    {
        var yoffset = 140;
        var space = 60;
        var posx = -330;
        var posy = 0;

        UpdateHelp();
        for (int i = 0; i < squareArray.Length; i++)
            if (squareArray[i] != null)
                Destroy(squareArray[i].gameObject);
        for (int i = 0; i < recette.steps.Length; i++)
        {
            if (i - 1 == recette.progress || i + 1 == recette.progress)
            {
                posx += 30;
                posy = 10 + yoffset;
            } else if (i == recette.progress) {
                posx += 50;
                posy = 0 + yoffset;
            }
            else
            {
                posx += 20;
                posy = 20 + yoffset;
            }
            Square tmp;
            tmp = (Instantiate(square, new Vector3(posx, posy, 0), Quaternion.identity) as Square);
            tmp.transform.SetParent(this.transform, false);
            squareArray[i] = tmp;
            posx += space;
            if (i - 1 == recette.progress || i + 1 == recette.progress)
            {
                RectTransform rt = (RectTransform)squareArray[i].transform;
                rt.sizeDelta = new Vector2(60, 60);
            }
            if (i == recette.progress)
            {
                RectTransform rt = (RectTransform)squareArray[i].transform;
                rt.sizeDelta = new Vector2(90, 90);
                stepDescribe.text = recette.steps[i].desc;
            }
        }
    }

    void UpdateHelp()
    {
        if (recette.progress >= 2 && recette.progress < 6) // Attention c'est degueu ça le refait à chaque fois
        {
            help.GetComponent<MeshFilter>().mesh = squareMesh;
            Vector3 scale = help.transform.localScale;
            scale.x = 0.035F;
            scale.y = 0.007F;
            scale.z = 0.007F;
            help.transform.eulerAngles = new Vector3(0, 0, 0);
            help.transform.localScale = scale;
        }
        else if (recette.progress >= 6 && recette.progress < 7)
        {
            help.GetComponent<MeshFilter>().mesh = tubeMesh;
            Vector3 scale = help.transform.localScale;
            scale.x = 0.025F;
            scale.y = 0.06F;
            scale.z = 0.025F;
            help.transform.eulerAngles = new Vector3(0, 0, 90);
            help.transform.localScale = scale;
        }
        else if (recette.progress >= 7)
        {
            help.GetComponent<MeshFilter>().mesh = tubeMesh;
            Vector3 scale = help.transform.localScale;
            scale.x = 0.03F;
            scale.y = 0.01F;
            scale.z = 0.03F;
            help.transform.localScale = scale;
        }
        else
        {

        }
    }

    public void NextStep()
    {
        recette.progress += 1;
        if (recette.progress >= recette.steps.Length)
        {
            //SceneManager.LoadScene(0);
            recette.progress = 0;
        }
        UpdateHud();
    }

    public void PrevStep()
    {
        recette.progress -= 1;
        if (recette.progress < 0)
            recette.progress = 0;
        UpdateHud();
    }
}