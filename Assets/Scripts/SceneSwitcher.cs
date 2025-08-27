using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public string SampleScene;

    public void Button()
    {
        SceneManager.LoadScene(SampleScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
