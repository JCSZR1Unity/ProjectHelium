using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime = 5f;
    public GameObject explosion;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimeCountdown();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                DestroyBullet();
                //TODO: Implement kill player function or something
                break;
            case "Weapon":
                Destroy(this.gameObject);
                //TODO: on the player side - count score or something
                //TODO: On Weapon script - fancy slice noise
                break;
            case "Cannon":
                break;
            default:
                DestroyBullet();
                break;
        }
    }

    void LifeTimeCountdown()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        //Instantiate(explosion, transform.position, transform.rotation);
        //TODO: Get explosion asset and KABOOM audioclip
        Destroy(this.gameObject);
    }
}
