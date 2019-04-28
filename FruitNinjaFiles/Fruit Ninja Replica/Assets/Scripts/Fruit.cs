using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour {

    public static float scaleMult;
    public Transform wholeFruit;
    public Transform cutFruit;
    public GameObject fruitSlicedPrefab;
	public float startForce = 15f;
	Rigidbody2D rb;



	void Start ()
	{

        
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

    private void Update()
    {
        Debug.Log(scaleMult + " current multiplier");
        wholeFruit.localScale = new Vector3(1f * scaleMult, 1f * scaleMult, 1f * scaleMult);
        cutFruit.localScale = new Vector3(1f * scaleMult, 1f * scaleMult, 1f * scaleMult);
    }
    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{

           
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
            
		}
        if (col.tag == "GroundZero")
        {
            Destroy(gameObject);
        }

    }





}
