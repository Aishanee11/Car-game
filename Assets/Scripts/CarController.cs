using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotationSpeed;
    public float moveSpeed;
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    public Transform cartransform;

    private float originalSpeed;
    private bool isBoosting = false;

    void Start()
    {
        originalSpeed = moveSpeed;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.01f)
        {
            cartransform.Rotate(0f, 0f, -rotationSpeed * horizontal * Time.deltaTime);
        }
        if (Mathf.Abs(vertical) > 0.01f)
        {
            cartransform.Translate(0f, moveSpeed * vertical * Time.deltaTime, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tree":
                Debug.Log("Your Car hit a Tree Aghh!!");
                break;
            case "Rocks":
                Debug.Log("Your Car hit the Rocks Aghh!!");
                break;
            case "Flag":
                Debug.Log("Congratulations!! You completed the race!");
                break;
            case "Roads":
                Debug.Log("Your Car hit the boundary.");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost") && !isBoosting)
        {
            isBoosting = true;
            moveSpeed *= boostMultiplier;
            Destroy(other.gameObject);
            Invoke(nameof(ResetSpeed), boostDuration);
        }
    }

    void ResetSpeed()
    {
        moveSpeed = originalSpeed;
        isBoosting = false;
    }
}

