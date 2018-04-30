using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float Vitesse;
    public float Saut;

    bool cooldownOne;
    bool cooldownTwo;

    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    Rigidbody2D RigidPlayerOne;
    Rigidbody2D RigidPlayerTwo;

    // Use this for initialization
    void Start () {
        RigidPlayerOne = PlayerOne.GetComponent<Rigidbody2D>();
        RigidPlayerTwo = PlayerTwo.GetComponent<Rigidbody2D>();
        cooldownOne = false;
        cooldownTwo = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        //Horizontal of Player One

        Vector2 OneDeplacement = new Vector2(Input.GetAxis("P1_Horizontal") * Vitesse * Time.deltaTime, 0);

        Vector2 newposOne = PlayerOne.transform.position;
        newposOne += OneDeplacement;
        PlayerOne.transform.position = newposOne;

        //Horizontal of Player Two

        Vector2 TwoDeplacement = new Vector2(Input.GetAxis("P2_Horizontal") * Vitesse * Time.deltaTime, 0);

        Vector2 newposTwo = PlayerTwo.transform.position;
        newposTwo += TwoDeplacement;
        PlayerTwo.transform.position = newposTwo;

        //Jump of Player One

        if ((!cooldownOne) && (Input.GetKeyDown(KeyCode.Space)))
        {
            RigidPlayerOne.AddForce(Vector2.up * Saut);
            cooldownOne = true;
            StartCoroutine(WaitForJumpOne(1));
        }

        //Jump of Player Two

        if ((!cooldownTwo) && (Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            RigidPlayerTwo.AddForce(Vector2.up * Saut);
            cooldownTwo = true;
            StartCoroutine(WaitForJumpTwo(1));
        }


    }
    IEnumerator WaitForJumpOne(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cooldownOne = false;
    }

    IEnumerator WaitForJumpTwo(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cooldownTwo = false;
    }
}
