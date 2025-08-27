using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public bool HideIfZeroScore = false;
    void Update()
    {
        var text = GetComponent<TMPro.TextMeshProUGUI>();
        if (HideIfZeroScore && ScoreCounter.Score == 0)
        {
            text.text = "";
            return;
        }
        
        text.text = $"Score: {ScoreCounter.Score}";
    }
}
