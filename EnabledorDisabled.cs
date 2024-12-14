using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledorDisabled : MonoBehaviour
{
    public GameObject image;

    public void Trigger(){
        if(image.activeInHierarchy == false ) {
            image.SetActive(true);
        }
        else {
            image.SetActive(false);
        }
    }
}
