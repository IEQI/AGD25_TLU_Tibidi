using UnityEngine;

public class DialogueTriggerZone : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            // your full dialogue array:
            DialogueLine[] dialogue = new DialogueLine[]
            {
                new DialogueLine { characterName = "Student",   text = "So professor, the red guy in the middle is the virus, that's the player" },
                new DialogueLine { characterName = "Professor", text = "And the green ones around it?" },
                new DialogueLine { characterName = "Student",   text = "Those are proteins, the goal is to connect the same color ones together" },
                new DialogueLine { characterName = "Professor", text = "And what happens when you do that?" },
                new DialogueLine { characterName = "Student",   text = "It unlocks more types of proteins, the player progresses by connecting all of them" },
                new DialogueLine { characterName = "Professor", text = "I see… and what are the blue ones on the right side?" },
                new DialogueLine { characterName = "Student",   text = "Those are antibodies, if they touch the virus, you lose health" },
                new DialogueLine { characterName = "Professor", text = "Okay nice. Don’t make them too smart, just basic patrol or follow mechanics should work" },
                new DialogueLine { characterName = "Student",   text = "Yeah that’s what I was thinking too, otherwise it becomes too hard to balance" },
                new DialogueLine { characterName = "Professor", text = "And the player moves between levels, right?" },
                new DialogueLine { characterName = "Student",   text = "Yeah there are two levels, player can move back and forth, that cave on the right takes you to level 2" },
                new DialogueLine { characterName = "Professor", text = "Good, keep the transitions smooth" },
                new DialogueLine { characterName = "Student",   text = "Next I’m gonna start placing the UI – like health bar, protein count, and dialogue text" },
                new DialogueLine { characterName = "Professor", text = "Great, also add sound effects when proteins connect, makes it feel more satisfying" },
                new DialogueLine { characterName = "Student",   text = "Yep, on it. Also gonna book the lab for Thursday so I can test movement and transitions properly" },
                new DialogueLine { characterName = "Professor", text = "Perfect, looking forward to seeing the progress" }
            };

            dialogueManager.StartDialogue(dialogue);
        }
    }
}
