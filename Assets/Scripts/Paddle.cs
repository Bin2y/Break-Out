using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<PlayerInput>().camera;
    }

    public void OnMove(InputValue input)
    {
        Vector2 position = input.Get<Vector2>();
        transform.position = new Vector3(Mathf.Clamp(cam.ScreenToWorldPoint(position).x, -7f, 7f), transform.position.y, transform.position.z);
    }
}
