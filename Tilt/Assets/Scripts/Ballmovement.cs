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


    private int score;

    private Rigidbody rb;

    [SerializeField]
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coinSource.clip = coinSound;
        score = 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(this.transform.position.y < -10)
        {
            LoadLoseScreen();
        }

        if(score == 28)
        {
            LoadWinScreen();
        }

        scoreText.text = "Score: " + score.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coinSource.Play();
            score++;
        }
    }

    private void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScene");
    }

    private void LoadWinScreen()
    {
        SceneManager.LoadScene("WinScene");
    }
    /*
    // Update is called once per frame
    void Update()
    {
        var up_and_down = Input.GetAxis("Vertical");
        var left_and_right = Input.GetAxis("Horizontal");

        this.transform.Translate(left_and_right * speed * Time.deltaTime, up_and_down * speed * Time.deltaTime, 0f);
    }
    */

}
