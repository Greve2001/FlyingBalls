using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public int sceneToLoad;
    public int sceneToUnload;
    private int i = 0;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.UnloadSceneAsync(sceneToUnload);
            Debug.Log("Unloaded Scene");

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnTriggerEnter(Collider collided)
    {
        if (i == 0)
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
            Debug.Log("Loaded Scene");
            i = 1;
        }
    }

}
