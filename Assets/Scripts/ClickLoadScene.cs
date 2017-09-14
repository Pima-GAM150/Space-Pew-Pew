using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickLoadScene : MonoBehaviour {

    public string nextScene;

    public void Click()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

}
