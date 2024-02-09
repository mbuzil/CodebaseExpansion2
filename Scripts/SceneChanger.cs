using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Seedling")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            /*if (NextScene.isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(NextScene.name));
            }*/
        }
    }
}
