using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour {

    [SerializeField]
    Text codeText;
    string codeTextValue = "";

    // Update is called once per frame
    void Update () {
        codeText.text = codeTextValue;

        // Check if the code is valid (any 5 digits)
        if (codeTextValue.Length == 5) {
            Kalbo.isSafeOpened = true; // Mark safe as opened
            codeTextValue = "";      // Reset code input
        }
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
