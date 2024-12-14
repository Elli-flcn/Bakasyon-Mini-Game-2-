using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Kalbo") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
