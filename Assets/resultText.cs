using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultText : MonoBehaviour
{
    TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent < TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Get().victory)
        {
            text.text = "You've won!";
        }
        else
        {
            text.text = "You've lost!";
        }
    }
}
