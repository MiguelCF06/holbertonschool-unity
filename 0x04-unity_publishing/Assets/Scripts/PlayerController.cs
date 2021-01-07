using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Image winLoseBG;
    public Text winLoseText;
    private int score = 0;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(LoadScene(3));
            DisplayYouLose();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rigidbody.AddForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rigidbody.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidbody.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidbody.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            StartCoroutine(LoadScene(3));
            DisplayYouWin();
        }
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void DisplayYouWin()
    {
        winLoseText.text = "You Win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
        winLoseBG.transform.gameObject.SetActive(true);
    }

    void DisplayYouLose()
    {
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        winLoseBG.transform.gameObject.SetActive(true);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
