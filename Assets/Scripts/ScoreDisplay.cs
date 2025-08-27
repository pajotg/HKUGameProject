using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public bool HideIfZero;

    [Tooltip("Sprites for digits 0-9")] 
    public Sprite[] digits;
    [Tooltip("Prefab with an Image component for a digit")] 
    public GameObject digitPrefab;
    [Tooltip("Spacing between digits")] 
    public float digitSpacing = 40f;


    void Update()
    {
        var score = ScoreCounter.Score;
        string scoreStr = score.ToString();

        // Remove old digits
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        if (score == 0 && HideIfZero) { return; }

        // Instantiate new digits
        for (int i = 0; i < scoreStr.Length; i++)
        {
            int digit = scoreStr[i] - '0';
            if (digit < 0 || digit > 9) continue;
            GameObject go = Instantiate(digitPrefab, transform);
            var img = go.GetComponent<UnityEngine.UI.Image>();
            if (img && digits.Length > digit)
                img.sprite = digits[digit];
            // Position digit
            var rt = go.GetComponent<RectTransform>();
            if (rt)
                rt.anchoredPosition = new Vector2((i - (float)(scoreStr.Length - 1) / 2) * digitSpacing, 0);
        }
    }
}
