using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public event System.Action onPlayerDeath;

    float screenHalfWidthUsingWorldUnits;

    public float speed = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthUsingWorldUnits = Camera.main.orthographicSize * Camera.main.aspect + halfPlayerWidth;

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -screenHalfWidthUsingWorldUnits){
            transform.position = new Vector2(screenHalfWidthUsingWorldUnits, transform.position.y);
        }

        if(transform.position.x > screenHalfWidthUsingWorldUnits){
            transform.position = new Vector2(-screenHalfWidthUsingWorldUnits, transform.position.y);
        }

    }
    
    void  OnTriggerEnter2D(Collider2D triggerCollider) {
        if(triggerCollider.tag == "Falling Block"){
            if(onPlayerDeath!=null){
                onPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
