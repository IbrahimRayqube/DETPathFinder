using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class KeyBoardManager : MonoBehaviour
{
    public static KeyBoardManager Instance;
    public InputField textBox;
    //[SerializeField] TMP_InputField textBox;
    [SerializeField] TextMeshProUGUI printBox;

    private void Start()
    {
        Instance = this;
        printBox.text = "";
        textBox.text = "";
        textBox.MoveTextEnd(true);
        textBox.caretWidth = 2;
    }

    private void LateUpdate()
    {
        textBox.ActivateInputField();
        textBox.caretPosition = textBox.text.Length;
    }

    public void DeleteLetter()
    {
        if(textBox.text.Length != 0) {
            textBox.text = textBox.text.Remove(textBox.text.Length - 1, 1);
            SceneHandler.Instance.menuManager.updateLists();
        }
        if (textBox.text.Length == 0)
        {
            SceneHandler.Instance.menuManager.clearBtn.gameObject.SetActive(false);
        }
    }

    public void AddLetter(string letter)
    {
        //textBox.ActivateInputField();
        //textBox.Select();
        //textBox.caretPosition = textBox.text.Length;
        textBox.caretBlinkRate = 1;
        
        textBox.text = textBox.text + letter;
        SceneHandler.Instance.menuManager.updateLists();
        if (textBox.text.Length != 0)
        {
            SceneHandler.Instance.menuManager.clearBtn.gameObject.SetActive(true);
        }

        StartCoroutine(showCaret());
    }

    IEnumerator showCaret()
    {
      yield return new WaitForEndOfFrame();
        //    textBox.MoveTextEnd(true);
        //textBox.ActivateInputField();
        textBox.MoveTextEnd(true);
        textBox.caretPosition = textBox.text.Length;
    }

    public void SubmitWord()
    {
        //printBox.text = textBox.text;
        //textBox.text = "";
        // Debug.Log("Text submitted successfully!");
        gameObject.SetActive(false);
    }
}
