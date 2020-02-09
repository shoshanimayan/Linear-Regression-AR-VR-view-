using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
using TMPro; // required to use text mesh pro elements

public class GenDataViz : MonoBehaviour
{
    int scaleSize = 100;
    int scaleSizeFactor = 10;
    public GameObject graphContainer;
    int binDistance = 13;
    float offset = 0;

    //Add a label for the prediction year
    public TextMeshProUGUI textPredictionYear;


    // Use this for initialization
    void Start()
    {
        CreateGraph();
    }


    public void ClearChilds(Transform parent)
    {
        offset = 0;
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    // Here we allow the use to increase and decrease the size of the data visualization
    public void DecreaseSize()
    {
        scaleSize += scaleSizeFactor;
        CreateGraph();
    }

    public void IncreaseSize()
    {
        scaleSize -= scaleSizeFactor;
        CreateGraph();
    }

    //Reset the size of the graph
    public void ResetSize()
    {
        scaleSize = 100;
        CreateGraph();
    }



    public void CreateGraph()
    {
        Debug.Log("creating the graph");
        ClearChilds(graphContainer.transform);
        for (var i = 0; i < LinearRegression.quantityValues.Count; i++)
        {
            createBin(10, (int)LinearRegression.quantityValues[i] / scaleSize, 10, offset, ((int)LinearRegression.quantityValues[i] / scaleSize) / 2, graphContainer);
            offset += binDistance;
        }
        Debug.Log("creating the graph: " + LinearRegression.PredictionOutput);

        // Let's add the predictio as the last bar, only if the user made a prediction
        if (LinearRegression.PredictionOutput != 0)
        {
            createBin(10, LinearRegression.PredictionOutput / scaleSize, 10, offset, (LinearRegression.PredictionOutput / scaleSize) / 2, graphContainer);
            offset += binDistance;
            textPredictionYear.text = "Prediction of " + LinearRegression.PredictionYear;
        }
        else
        {
            textPredictionYear.text = " ";

        }
    }


    void createBin(float Scale_x, float Scale_y, float Scale_z, float Padding_x, float Padding_y, GameObject _parent)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(_parent.transform, true);

        cube.transform.position = new Vector3(Padding_x, Padding_y - 100, 400);

        // Let's add some colours
        cube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);


        Vector3 scale = new Vector3(Scale_x, Scale_y, Scale_z);

        cube.transform.localScale = scale;
    }

}


