using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Ballmovement : MonoBehaviour
{

    // Audio tutorial helped me add sound to this project https://www.youtube.com/watch?v=egxNXuwf0_g
    [SerializeField]
    private AudioClip coinSound;

    [SerializeField]
    private AudioSource coinSource;

    [SerializeField]
    private int speed;

    [SerializeField]
    private LevelMovement levelMovement;

    [SerializeField]
    private Camera mainCamera;

    public int score;

    private Rigidbody rb;

    [SerializeField]
    private Text scoreText;

    public bool done;

    //private Color StartingColor;
    //private Color EndingColor;

    [SerializeField]
    private List<Material> Skyboxes;

    [SerializeField]
    private Endgame endgame;

    private float lerpTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        RenderSettings.skybox = Skyboxes[0];
        rb = GetComponent<Rigidbody>();
        coinSource.clip = coinSound;
        score = 0;

       // StartingColor = RenderSettings.skybox.GetColor("_Tint");
        //  EndingColor = Color.red;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(score == 10)
        {
            RenderSettings.skybox = Skyboxes[1];
   
            //RenderSettings.skybox.SetColor("_Tint", Color.Lerp(StartingColor, EndingColor, Time.deltaTime * lerpTime));

        }
        if(score == 460)
        {
            endgame.WinCanvas();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        scoreText.text = "Score: " + score.ToString();

        if (done)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(new Vector3(0, 15), ForceMode.Impulse);
            done = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coinSource.Play();
            score+= 10;
        }           
        if (other.tag == "border")
        {
            endgame.LoseCanvas();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "StageFlip" && rb.constraints == RigidbodyConstraints.None)
        {
            if (transform.position.y < -.5f)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                if (levelMovement != null)
                {
                    levelMovement.FlipStage();
                }
            }
        }
        if (other.tag == "topleft" && transform.position.y > 0)
        {
            rb.AddForce(new Vector3(-2, 0, 2), ForceMode.Impulse);
        }
        else if (other.tag == "topright" && transform.position.y > 0)
        {
            rb.AddForce(new Vector3(2, 0, 2), ForceMode.Impulse);
        }
        else if (other.tag == "bottomleft" && transform.position.y > 0)
        {
            rb.AddForce(new Vector3(-2, 0, -2), ForceMode.Impulse);
        }
        else if (other.tag == "bottomright" && transform.position.y > 0)
        {
            rb.AddForce(new Vector3(2, 0, -2), ForceMode.Impulse);
        }
    }
}
