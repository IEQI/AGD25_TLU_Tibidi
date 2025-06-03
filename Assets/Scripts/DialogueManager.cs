// using UnityEngine;
// using UnityEngine.UI;

// public class DialogueManager : MonoBehaviour
// {
//     [Header("UI Panels")]
//     public GameObject UI_scientist;
//     public GameObject UI_student;

//     [Header("Text Components")]
//     public Text scientistText;
//     public Text studentText;

//     private DialogueLine[] lines;
//     private int currentLine = 0;

//     /// <summary>
//     /// Called by the trigger zone, passes in the full dialogue.
//     /// </summary>
//     public void StartDialogue(DialogueLine[] newLines)
//     {
//         lines = newLines;
//         currentLine = 0;
//         // immediately show the first line
//         ShowNextLine();
//     }

//     /// <summary>
//     /// Advances to the next line; shows/hides the correct UI.
//     /// </summary>
//     public void ShowNextLine()
//     {
//         if (currentLine < lines.Length)
//         {
//             var line = lines[currentLine];
//             bool isProfessor = line.characterName.ToLower().Contains("professor");

//             // toggle panels
//             UI_scientist.SetActive(isProfessor);
//             UI_student.SetActive(!isProfessor);

//             // set text
//             if (isProfessor) scientistText.text = line.text;
//             else studentText.text = line.text;

//             currentLine++;
//         }
//         else
//         {
//             // end: hide both
//             UI_scientist.SetActive(false);
//             UI_student.SetActive(false);
//         }
//     }

//     private void Update()
//     {
//         // on Space, advance if any dialogue panel is active
//         if ((UI_scientist.activeSelf || UI_student.activeSelf) && Input.GetKeyDown(KeyCode.Space))
//         {
//             ShowNextLine();
//         }
//     }
// }

// [System.Serializable]
// public class DialogueLine
// {
//     public string characterName;
//     public string text;
// }



using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Panels")]
    // public GameObject UI_scientist;
    // public GameObject UI_student;

    [Header("Text Components")]
    public TMPro.TextMeshProUGUI scientistText;
    public TMPro.TextMeshProUGUI studentText;

    private DialogueLine[] lines;
    private int currentLine = 0;

    public InputAction advanceText;


    private void Start()
    {
        // ensure both panels are hidden at start
        UI_scientist.SetActive(false);
        UI_student.SetActive(false);
    }

    /// <summary>
    /// Called by the trigger zone, passes in the full dialogue.
    /// </summary>
    public void StartDialogue(DialogueLine[] newLines)
    {
        lines = newLines;
        currentLine = 0;
        ShowNextLine(); // Immediately show the first line
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

            // Toggle panels
            UI_scientist.SetActive(isProfessor);
            UI_student.SetActive(!isProfessor);

            // Set text
            if (isProfessor)
                scientistText.text = line.text;
            else
                studentText.text = line.text;

            currentLine++;
        }
        else
        {
            // End of dialogue: hide both
            UI_scientist.SetActive(false);
            UI_student.SetActive(false);
        }
    }

    //private void Update()
    //{
    //    // on Space, advance if any dialogue panel is active

    //    advanceText = new InputAction(binding: "<Keyboard>/space");


    //    if ((UI_scientist.activeSelf || UI_student.activeSelf) && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ShowNextLine();
    //    }
    //}

    private void OnEnable()
    {
        advanceText.Enable();
        advanceText.performed += OnAdvanceText;
    }

    private void OnDisable()
    {
        advanceText.Disable();
        advanceText.performed -= OnAdvanceText;
    }

    private void OnAdvanceText(InputAction.CallbackContext context)
    {
        if (UI_scientist.activeSelf || UI_student.activeSelf)
        {
            Debug.Log("OnAdvanceText called.");
        }
    }

    /// <summary>
    /// Input System callback method for advancing dialogue.
    /// Hook this up via PlayerInput Unity Events.
    /// </summary>
    public void OnContinue(InputAction.CallbackContext context)
    {
        if (context.performed && (UI_scientist.activeSelf || UI_student.activeSelf))

        {
             Debug.Log("Advance triggered.");
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
