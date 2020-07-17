using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour
{
    static string defaultName = "Name";
    static List<string> sequence = new List<string>();
    public Dialog currentDialog; // text
    public Text textt; //temp
    public GameObject overlay; //temp
    int initialLineLimit = 50; //fix text

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(currentDialog.DialogSequence(textt, overlay, 3));
        }
    }


}
