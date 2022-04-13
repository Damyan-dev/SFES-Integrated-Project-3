
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTrigger : MonoBehaviour
{

    public GameObject barnOutside = null;
    public GameObject canvasObject;
    public string[] dialogue = { "Word A", "Word B" };
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        barnOutside.SetActive(true);
        canvasObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("entered");
            barnOutside.SetActive(false);
            canvasObject.SetActive(true);
            // log whatever comes out of the RandomWord string.
            string dialogueToDisplay = Randomdialogue();

            text.text = dialogueToDisplay;

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            barnOutside.SetActive(true);
            canvasObject.SetActive(false);
        }
    }
    private string Randomdialogue()
    {
        // grab a random string from the words array
        string randomdialogue = dialogue[Random.Range(0, dialogue.Length)];

        // return it (this will be the string that the script will use)
        return randomdialogue;
    }

}
