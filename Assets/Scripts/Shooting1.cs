using JetBrains.Annotations;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Fired");
            GameObject b = Instantiate(bullet, muzzle.position, muzzle.rotation);
            b.transform.up = muzzle.forward;

        }
    }
}
