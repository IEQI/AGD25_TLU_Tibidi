using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject UI_scientist;
    public GameObject UI_student;

    [Header("Text Components")]
    public Text scientistText;
    public Text studentText;

    private DialogueLine[] lines;
    private int currentLine = 0;

    /// <summary>
    /// Called by the trigger zone, passes in the full dialogue.
    /// </summary>
    public void StartDialogue(DialogueLine[] newLines)
    {
        lines = newLines;
        currentLine = 0;
        // immediately show the first line
        ShowNextLine();
    }

    /// <summary>
    /// Advances to the next line; shows/hides the correct UI.
    /// </summary>
    public void ShowNextLine()
    {
        if (currentLine < lines.Length)
        {
            var line = lines[currentLine];
            bool isProfessor = line.characterName.ToLower().Contains("professor");

            // toggle panels
            UI_scientist.SetActive(isProfessor);
            UI_student.SetActive(!isProfessor);

            // set text
            if (isProfessor) scientistText.text = line.text;
            else studentText.text = line.text;

            currentLine++;
        }
        else
        {
            // end: hide both
            UI_scientist.SetActive(false);
            UI_student.SetActive(false);
        }
    }

    private void Update()
    {
        // on Space, advance if any dialogue panel is active
        if ((UI_scientist.activeSelf || UI_student.activeSelf) && Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextLine();
        }
    }
}

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string text;
}
