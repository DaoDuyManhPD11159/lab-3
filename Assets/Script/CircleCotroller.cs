
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private int direction = 1;
    private float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, direction, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (transform.position.y > 1.5f || transform.position.y < -1.44)
        {
            direction *= -1;
        }
    }

    public int scoreValue = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Tăng điểm số khi viên đạn va chạm vào mục tiêu


            // Biến mục tiêu và viên đạn biến mất
            Destroy(gameObject); // Mục tiêu
            Destroy(collision.gameObject); // Viên đạn
        }
    }
}
