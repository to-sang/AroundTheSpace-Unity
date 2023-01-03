using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainController : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    public void playGameButton()
    {
        Sound("click_effect");
        //SceneManager.LoadScene("Intro");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Sound(string File)
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("Sound/" + File));
    }
}
