using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Restart : MonoBehaviour
{
    public TextMeshProUGUI score;
    public ScoreManager sm;

    private void Start()
    {
        score.text = ("Your Score: ") + sm.score.ToString();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q)) 
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
