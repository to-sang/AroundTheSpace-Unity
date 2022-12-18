using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGameButton()
    {
        SceneManager.LoadScene("playGameScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
