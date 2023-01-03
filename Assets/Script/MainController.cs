using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public void playGameButton()
    {
        SceneManager.LoadScene("Intro");
    }
    // Update is called once per frame
    void Update()
    {
    }
}
