using UnityEngine;

public class Arrow : MonoBehaviour{
    public float speed;
    public float damage;
    
    public Vector2 direction;
    public Rigidbody2D rb;

    private GameObject arrowPrefab;
    
    void Start(){
        rb.velocity = new Vector2(direction.x, direction.y) * speed;    
    }

}