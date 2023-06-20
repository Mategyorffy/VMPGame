using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform Player;
    public float YOffset;

    private Vector2 startPos;
    private float startZ;


    Vector2 travel => (Vector2)cam.transform.position - startPos;

    float distanceFromPlayer => transform.position.z - Player.position.z;

    float clippingPlane => (cam.transform.position.z + (distanceFromPlayer > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parralaxFactor => Mathf.Abs(distanceFromPlayer) / clippingPlane;


    private void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
        

    }

    private void Update()
    {
        Vector2 newPos = startPos + travel * parralaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y + YOffset, startZ);
    }
}
