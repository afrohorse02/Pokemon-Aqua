using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "NPCs/Generic NPC")]

public class Dialog : ScriptableObject
{
    //int initialLineLimit = 50;
    string dialogToOutput;
    public string npcName;
    public List<string> dialogueSequence = new List<string>();

    public IEnumerator DialogSequence(Text outputText, GameObject dialogOverlay, float scrollSpeed)
    {

        outputText.text = null;
        dialogOverlay.SetActive(true);
        foreach (string dialogLine in dialogueSequence) //Get all strings from the sequence
        {
            //List<string> words = new List<string>();
            //int wordCount = 0; 
            foreach (char dialogCharacter in dialogLine) //Get all characters from the string
            {
                dialogToOutput += dialogCharacter;
                outputText.text = dialogToOutput;
                yield return new WaitForSeconds(0.03f); //Use scroll speed instead of constant number
            }
            yield return WaitForKeyPress(KeyCode.A);
            dialogToOutput = null;
            outputText.text = null;
        }
        dialogOverlay.SetActive(false);
        yield return 0;
    }

    IEnumerator WaitForKeyPress(KeyCode key)
    {
        bool input = false;
        while (!input)
        {
            if (Input.GetKeyDown(key))
            {
                input = true;
            }
            yield return null;
        }
    }
}
