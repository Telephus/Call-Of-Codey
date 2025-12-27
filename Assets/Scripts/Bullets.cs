using UnityEngine;

public class Bullets : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject effectPrefab;
    public GameObject impactEffectPrefab;
    public GameObject projectilePrefab;

    public Transform muzzlePoint;

    public float speed = 20f;
    public float lifetime = 2.0f;
    public float effectDuration = 2.0f;
    //public Vector3 direction = Vector3.forward;
        
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);
        Destroy(gameObject, effectDuration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = transform.up * speed;
        /*
        RaycastHit hit;s
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("splash");
        }

        if (Physics.Raycast(transform.position, Vector3.forward, 10))
        {
            //Debug.Log("here");
        }
        */
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile"))
        {
            if (effectPrefab != null)
            {
                ContactPoint contact = collision.GetContact(0);
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 pos = contact.point;
                Instantiate(effectPrefab, collision.contacts[0].point, Quaternion.identity);
                //Instantiate(effectPrefab, contact.point, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
