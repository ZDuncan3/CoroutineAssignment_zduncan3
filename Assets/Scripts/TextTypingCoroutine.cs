using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTypingCoroutine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textElement;
    [SerializeField] string textToType = "GAME-121 Coroutine Assignment";

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = "";
        StartCoroutine(TypeThisText());
    }

    //Coroutine example 2, text typing
    IEnumerator TypeThisText()
    {
        int i = 0;
        while (i < textToType.Length)
        {
            textElement.text += textToType[i];
            i++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
