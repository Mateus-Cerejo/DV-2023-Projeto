using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float width;
    [SerializeField] private float height;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.z - transform.position.z
        );

        Debug.Log(direction);
        transform.Translate(direction, Space.World);
    }
}
