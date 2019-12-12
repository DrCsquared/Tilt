using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public int score;

    private Rigidbody rb;

    public bool done;

    //private Color StartingColor;
    //private Color EndingColor;

    [SerializeField]
    private List<Material> Skyboxes;

    [SerializeField]
    private Endgame endgame;

    [SerializeField]
    private List<Material> BallMaterials;

    private float lerpTime = 1.0f;

    [SerializeField]
    List<GameObject> teleporters = new List<GameObject>();

    private int BallMaterial;

    private float timer;

    Inventory powerups = new Inventory();

    public bool frozen;

    private float freezeTimer;

    [SerializeField]
    private GameObject jCount;

    [SerializeField]
    private GameObject fCount;


    // Start is called before the first frame update
    void Start()
    {
        
        BallMaterial = PlayerPrefs.GetInt("BallMaterial", 0);

        this.gameObject.GetComponent<MeshRenderer>().material = BallMaterials[BallMaterial];
        

        RenderSettings.skybox = Skyboxes[0];
        rb = GetComponent<Rigidbody>();
        coinSource.clip = coinSound;
        score = 0;

       // StartingColor = RenderSettings.skybox.GetColor("_Tint");
        //  EndingColor = Color.red;

    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(score == 400)
        {
            RenderSettings.skybox = Skyboxes[1];
   
            //RenderSettings.skybox.SetColor("_Tint", Color.Lerp(StartingColor, EndingColor, Time.deltaTime * lerpTime));

        }
        if(score == 460)
        {
            endgame.WinCanvas();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (done)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(new Vector3(0, 15), ForceMode.Impulse);
            done = false;
        }
        if (frozen)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer > 20)
            {
                frozen = false;
                levelMovement.frozen = false;
                freezeTimer = 0;
            }
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
        if (other.tag == "teleporter" && timer > .2)
        {
            timer = 0;
            int newtele = Random.Range(0,teleporters.Count);
            if (newtele < 4 && (other.gameObject.name == "Teleporter" || other.gameObject.name == "Teleporter (1)" || other.gameObject.name == "Teleporter (2)" || other.gameObject.name == "Teleporter (3)"))
            {
                newtele = Random.Range(4,teleporters.Count);
            }
            while (teleporters[newtele].gameObject.transform == other.transform)
            {
                newtele = Random.Range(0, teleporters.Count);
            }
            transform.position = teleporters[newtele].transform.position;
            transform.position += new Vector3 (0,.2f);
        }
        if(other.tag == "jumppower")
        {
            coinSource.Play();
            powerups.jumpPowerup++;
            jCount.GetComponent<TextMeshPro>().text = powerups.jumpPowerup.ToString();
            Debug.Log(powerups.jumpPowerup);
        }
        if (other.tag == "freezepower")
        {
            coinSource.Play();
            powerups.freezePowerup++;
            fCount.GetComponent<TextMeshPro>().text = powerups.freezePowerup.ToString();
            Debug.Log(powerups.freezePowerup);
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

    public void Jump()
    {
        if (powerups.jumpPowerup > 0)
        {
            powerups.jumpPowerup--;
            jCount.GetComponent<TextMeshPro>().text = powerups.jumpPowerup.ToString();
            rb.AddForce(new Vector3(0,-2), ForceMode.Impulse);
        }
    }

    public void Freeze()
    {
        if (powerups.freezePowerup > 0)
        {
            powerups.freezePowerup--;
            fCount.GetComponent<TextMeshPro>().text = powerups.freezePowerup.ToString();
            levelMovement.frozen = true;
            frozen = true;
        }
    }
}
