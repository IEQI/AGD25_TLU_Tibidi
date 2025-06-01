using TMPro;
using UnityEngine;

public class GameUiManager : MonoBehaviour
{
    public TMP_Text Pan_Dial_L;
    public TMP_Text Pan_Dial_R;

    public void UpdateDialTexts(string objName)
    {
        string message = $"Hi from {objName}";
        Pan_Dial_L.text = message;
        Pan_Dial_R.text = message;
    }
}
