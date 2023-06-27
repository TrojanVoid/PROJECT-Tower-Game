using UnityEngine;

public class Tower : MonoBehaviour{
    public float range;
    public float attackSpeed = 1.0f;
    
    public Transform rangeCircle;

    void Update(){
        // TODO Call this function ONLY when user triggers an EVENT that CHANGES the RANGE of the tower
        UpdateRangeCircle();
    }

    private void UpdateRangeCircle(){
        rangeCircle.localScale = new Vector3(range, range, 1);
    }

}