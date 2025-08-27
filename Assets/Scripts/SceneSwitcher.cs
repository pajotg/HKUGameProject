using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public string SampleScene;

    public AudioSource source;
    public AudioClip ButtonClip;

    public void Button()
    {
        source.PlayOneShot(ButtonClip);
        SceneManager.LoadScene(SampleScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
