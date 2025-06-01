using UnityEngine;

public class DialogueTriggerZone : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player") && PlayerSaveStatus.hasRunOnce == false)
        {
            hasTriggered = true;

            // your full dialogue array:
            DialogueLine[] dialogue = new DialogueLine[]
            {
                new DialogueLine { characterName = "Student",   text = "Are we really looking at a virus, professor?" },
                new DialogueLine { characterName = "Professor", text = "Indeed so and what is that on the right?" },
                new DialogueLine { characterName = "Student",   text = "Looks like a big cell" },
                new DialogueLine { characterName = "Professor", text = "Right again, the virus is trying to infiltrate it." },
                new DialogueLine { characterName = "Student",   text = "There seems to be another smaller cell above the virus" },
                new DialogueLine { characterName = "Professor", text = "Exactly, the virus will use the smaller cells for it's own purposes." },
                new DialogueLine { characterName = "Student",   text = "It was something to do with protein manufacturing" },
                new DialogueLine { characterName = "Professor", text = "Yes, if you study the surface of the virus and the cell, what do you see?" },
                new DialogueLine { characterName = "Student",   text = "Aah, now I remember, on the virus there are spike proteins and on the cell receptors" },
                new DialogueLine { characterName = "Professor", text = "But what would happen if the virus attaches it's protein to the cell?" },
                new DialogueLine { characterName = "Student",   text = "The cell would accept it?" },
                new DialogueLine { characterName = "Professor", text = "Yes, but will the cell accept any protein?" },
                new DialogueLine { characterName = "Student",   text = "It was supposed to be the right type, right?" },
                new DialogueLine { characterName = "Professor", text = "Right! The virus can attach only a specific kind of spike to a specific receptor" },
                new DialogueLine { characterName = "Student",   text = "And that is when the synthesis of new proteins happens right?" },
                new DialogueLine { characterName = "Professor", text = "Correct, the cell can then pick up newly synthesised proteins to attack new cells" },
                new DialogueLine { characterName = "Student",   text = "Nature sure is amazing!" }
            };

            dialogueManager.StartDialogue(dialogue);
        }
    }
}
