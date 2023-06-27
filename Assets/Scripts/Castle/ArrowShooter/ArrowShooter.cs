using System.Collections.Generic;

using UnityEngine;

public class ArrowShooter : MonoBehaviour {
    public GameObject arrowPrefab;

    private float range;
    private float attackSpeed;
    private float attackCooldown;
    private float timeSinceLastShot;
    private List<GameObject> enemies;

    void Start(){
        UpdateProperties();
    }

    private void UpdateProperties(){
        Tower tower = GetComponentInParent<Tower>();
        range = tower.range;
        attackSpeed = tower.attackSpeed;
        attackCooldown = 1f/attackSpeed;
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update(){
        UpdateProperties();
        timeSinceLastShot += Time.deltaTime;
        if(timeSinceLastShot >= attackCooldown){
            Vector3 shootDirection = FindNearestEnemyDirectionInRange();
            if(shootDirection != new Vector3(0,0,0)){
                ShootArrowInDirection(shootDirection);
                timeSinceLastShot = 0f;
            }
        }
    }

    


    private void ShootArrowInDirection(Vector3 direction){
        GameObject arrow = Instantiate(arrowPrefab, GameObject.Find("Tower").transform);
        float rotationOffset = -60f;
        arrow.transform.position = transform.position;
        arrow.GetComponent<Arrow>().direction = direction;
        arrow.transform.rotation = Quaternion.identity;
        float angle = Vector2.Angle(
            new Vector2(transform.position.x, transform.position.y),
            new Vector2(direction.x, direction.y));
        angle = transform.position.x < direction.x ? angle : 360f - angle;
        angle += rotationOffset;
        Debug.Log("ANGLE: " + angle.ToString());
        arrow.transform.Rotate(new Vector3(0, 0, angle));
    }

    

    private Vector3 FindNearestEnemyDirectionInRange(){
        GameObject nearestEnemy = null;
        float minDistance = 999999;
        Vector2 enemy = new Vector2(0,0);
        Vector2 tower = new Vector2(0,0);
        foreach(GameObject enemyObject in enemies){
            enemy = new Vector2(enemyObject.transform.position.x, enemyObject.transform.position.y);
            tower = new Vector2(transform.position.x, transform.position.y);
            float distance = Vector2.Distance(enemy, tower);
            if(distance <= range && distance < minDistance){
                minDistance = distance;
                nearestEnemy = enemyObject;
            }
        }
        if(nearestEnemy != null){
            Vector2 direction = Vector2.MoveTowards(tower, enemy, 1).normalized;
            return direction;
        }
        return new Vector3(0,0,0);
    }

}