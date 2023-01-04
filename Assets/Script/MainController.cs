using System;
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
        StartCoroutine(TypeLine());
        SceneManager.LoadScene("tutorial");
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

        Debug.Log(Resources.Load<AudioClip>("Sound/" + File).name);
        audio.PlayOneShot(Resources.Load<AudioClip>("Sound/" + File));
    }
    IEnumerator TypeLine()
    {
            yield return new WaitForSeconds(1f);
    }
}
