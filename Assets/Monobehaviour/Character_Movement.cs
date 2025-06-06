//Title: Character Movement Mechanic
//Author : Matthew 1834243@students.wits.ac.za
//Date : 24-04-2025
//Availability : Ulwazi under Modules


using UnityEngine;
public class Character001 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public SpriteRenderer spriteRenderer;
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
        }
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}

