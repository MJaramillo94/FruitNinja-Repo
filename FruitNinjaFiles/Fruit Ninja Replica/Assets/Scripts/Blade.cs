using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour {

    public static int count;
    public Text ScoreText;

    public Transform blade;
  

    public TrailRenderer bladeTrail;

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

    public static float mult;
    public static float trailDelay;
    public static float trailSize;

	bool isCutting = false;

	Vector2 previousPosition;

	GameObject currentBladeTrail;
   

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
        
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

        blade.localScale = new Vector3(1f * mult , 1f * mult, 1f  * mult);
        bladeTrail.widthMultiplier = trailSize;
        bladeTrail.time = trailDelay;
       

        Debug.Log(mult + "cur0rent blade multiplier");

	}

	void UpdateCut ()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		} else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fruit")
        {
            count++;
            SetScoreText();
            
        }
    }

    public void SetScoreText()
    {
        ScoreText.text = "Score : " + count.ToString();
    }
}
