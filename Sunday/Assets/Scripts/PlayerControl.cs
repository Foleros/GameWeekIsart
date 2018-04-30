using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float Vitesse;
    public float Saut;

    int DirectionOne;
    public static int DirectionTwo;

    bool cooldownOne;
    bool cooldownTwo;

    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public GameObject OneHitZone;
    public GameObject Arrow;


    Rigidbody2D RigidPlayerOne;
    Rigidbody2D RigidPlayerTwo;


    // Use this for initialization
    void Start () {
        RigidPlayerOne = PlayerOne.GetComponent<Rigidbody2D>();
        RigidPlayerTwo = PlayerTwo.GetComponent<Rigidbody2D>();
        cooldownOne = false;
        cooldownTwo = false;
        OneHitZone.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
        //Horizontal of Player One

        Vector2 OneDeplacement = new Vector2(Input.GetAxis("P1_Horizontal") * Vitesse * Time.deltaTime, 0);

        Vector2 newposOne = PlayerOne.transform.position;
        newposOne += OneDeplacement;
        PlayerOne.transform.position = newposOne;

        //Direction of Player One

        if(Input.GetAxis("P1_Horizontal") > 0.01f)
        {
            DirectionOne = 0;
            PlayerOne.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Input.GetAxis("P1_Horizontal") < -0.01f)
        {
            DirectionOne = 1;
            PlayerOne.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        //Horizontal of Player Two

        Vector2 TwoDeplacement = new Vector2(Input.GetAxis("P2_Horizontal") * Vitesse * Time.deltaTime, 0);

        Vector2 newposTwo = PlayerTwo.transform.position;
        newposTwo += TwoDeplacement;
        PlayerTwo.transform.position = newposTwo;

        //Direction of Player Two

        if (Input.GetAxis("P2_Horizontal") > 0.01f)
        {
            DirectionTwo = 0;
            PlayerTwo.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        else if (Input.GetAxis("P2_Horizontal") < -0.01f)
        {
            DirectionTwo = 1;
            PlayerTwo.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        //Jump of Player One

        if ((!cooldownOne) && (Input.GetKeyDown(KeyCode.Z)))
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

        //SpellOne First Player

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OneHitZone.SetActive(true);
            StartCoroutine(TimeAttack(1));
        }

        //SpellOne Second Player

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            GameObject go = Instantiate(Arrow);
            go.transform.position = PlayerTwo.transform.position;
            go.transform.rotation = PlayerTwo.transform.rotation;
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

    IEnumerator TimeAttack(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        OneHitZone.SetActive(false);
    }

}
