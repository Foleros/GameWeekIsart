using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    int direction;

    bool Cool;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        Cool = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction == 0)
        {
            if (Input.GetAxis("P2_Horizontal") > 0.01f && Input.GetKeyDown(KeyCode.JoystickButton1)&&Cool==false)
            {
                direction = 1;
            }

            else if (Input.GetAxis("P2_Horizontal") < -0.01f && Input.GetKeyDown(KeyCode.JoystickButton1) && Cool == false)
            {
                direction = 2;
            }

            else if (Input.GetAxis("Vertical") > 0.01f && Input.GetKeyDown(KeyCode.JoystickButton1) && Cool == false)
            {
                direction = 3;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                rb.velocity = new Vector2(0, 0);
                dashTime = startDashTime;
                

            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    Cool = true;
                    StartCoroutine(Cooldown(0.8f));

                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    Cool = true;
                    StartCoroutine(Cooldown(0.8f));

                }
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up *2* dashSpeed;
                    Cool = true;
                    StartCoroutine(Cooldown(0.8f));

                }
            }
        }
    }

    IEnumerator Cooldown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Cool = false;
    }
}
