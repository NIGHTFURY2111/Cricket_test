using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuck : MonoBehaviour
{
[SerializeField] private float speed = 5f;

    public void movePuck(Vector2 PlayerInput)
    {
        Vector3 direction = new Vector3 (PlayerInput.x, 0f , PlayerInput.y);
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
