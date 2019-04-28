using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Dropdown FruitSize;
    public Dropdown FruitSpeed;
    public Dropdown BladeSize;
   

    public static float fruitSize;
    public static float fruitSpeed;
    public static float bladeZize;
    public static float bladeTrail;
    public static float trailSize;
    public static float fruitForce;

    // Update is called once per frame
    void Update()
    {

        #region FruitSize
        switch (FruitSize.value)
        {
            case 1:
                Debug.Log("case 1 selected");
            
                fruitSize = .75f;
                break;
            case 2:
                Debug.Log("case 2 selected");
              
                fruitSize = 1f;
                break;
            case 3:
                Debug.Log("case 3 selected");
    
                fruitSize = 1.5f;
                break;
        }
        #endregion

        #region FruitSpeed
        switch (FruitSpeed.value)
        {
            case 1:

                fruitSpeed = 3f;
                break;

            case 2:
                fruitSpeed = 1.5f;
                break;
            case 3:

                fruitSpeed = .5f;
                break;
        
        }
        #endregion

        #region BladeSize
        switch (BladeSize.value)
        {
            case 1:
                trailSize = .1f;
                bladeTrail = .1f;
                bladeZize = .5f;
                break;

            case 2:
                trailSize = .5f;
                bladeTrail = .25f;
                bladeZize = 1f;
                break;
            case 3:
                trailSize = 1f;
                bladeTrail = .5f;
                bladeZize = 2f;
                break;
        }
        #endregion


    }

    public void StartGame ()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Application terminated.");
    }

    public void PlayAgain()
    {
        Blade.count = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void BeginWithSettings()
    {
        Fruit.scaleMult = fruitSize;
        FruitSpawner.maxDelay = fruitSpeed;
        Blade.mult = bladeZize;
        Blade.trailDelay = bladeTrail;
        Blade.trailSize = trailSize;

    }
}
