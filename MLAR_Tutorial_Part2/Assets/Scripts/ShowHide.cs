using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{

    public GameObject showHideObj;

    public void ShowHideTask()
    {
        if (showHideObj.activeSelf)
        {
            showHideObj.SetActive(false);

        }
        else
        {
            showHideObj.SetActive(true);
        }
    }

}