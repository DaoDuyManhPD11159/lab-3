using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    // Update is called once per frame
    public float timeRemaining = 60;
    public Text countdownText;
    void Start()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " +timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(x: horizontal, y: vertical, z: 0f).normalized;
        transform.Translate(movement * 5f * Time.deltaTime);
    }
    public void LoadNextSence()
    {
        int currentSenceIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSenceIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Circle"))
        {
            Debug.Log("xxxx");
            Vector2 firstPosition = new Vector2( -8, 1);
            transform.position = (Vector3)firstPosition;
        }
        if (col.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextSence();
        }
    }
}

