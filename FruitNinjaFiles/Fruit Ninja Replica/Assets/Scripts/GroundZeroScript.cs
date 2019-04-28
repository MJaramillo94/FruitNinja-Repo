using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GroundZeroScript : MonoBehaviour
{
    public int Lives = 5;
    public Text LivesText;

    public void Start()
    {
        LivesText.text = Lives.ToString() + 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        

            if (col.tag == "Fruit")
            {
            Lives--;
            LivesText.text = Lives.ToString() + 1;
                
            }
        
    }
    
public void Update()
    {
        LivesText.text = Lives.ToString();
        if (Lives <= 0)
        {

            Debug.Log("Game OVER!!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
