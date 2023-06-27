using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    
    public float damage;
    public float range;

    public Rigidbody2D rb;

    private Transform towerTransform;

    void Start()
    {
        towerTransform = GameObject.Find("TowerShape").transform;
        DetermineVelocity();
    }

    private void DetermineVelocity(){
        Vector3 moveDirection = Vector3.MoveTowards(towerTransform.position, transform.position, 10);
        Vector3 movementVector = -Vector3.Normalize(moveDirection) * moveSpeed;
        rb.velocity = new Vector2(movementVector.x, movementVector.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTowerInRange()){
            rb.velocity = new Vector2(0,0);
        }
    }

    private bool IsTowerInRange(){
        Vector3 self = transform.position;
        self.z = 0;
        Vector3 tower = towerTransform.position;
        tower.z = 0;
        return Vector3.Distance(tower, self) <= range;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Weapon"){
            Destroy(gameObject, 0f);
            Destroy(collision.gameObject, 0f);
        }
    }
}
