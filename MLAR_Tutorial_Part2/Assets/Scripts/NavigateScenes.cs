using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class NavigateScenes : MonoBehaviour {
    public enum nav { norm, vr, ar }
    public nav choice;
    public void LoadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "tutorial")
        {
            SceneManager.LoadScene("tutorial");
        }
        else
        {
            switch (choice) {
                case nav.norm:
                    SceneManager.LoadScene(1);
                    break;
                case nav.vr:
                    SceneManager.LoadScene(2);
                    break;
                case nav.ar:
                    SceneManager.LoadScene(3);
                    break;
                default:
                    break;

            }
        }
    }
}
