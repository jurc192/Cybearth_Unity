using UnityEngine;
using System.Collections;

public class EnemyDrop : MonoBehaviour {
    static GameObject healthBox = Resources.Load("HP_FBX") as GameObject;
    static GameObject ammoBox = Resources.Load("AMMO_FBX") as GameObject;

    public static void GetLucky(Vector3 position)
    {
        bool shouldIDropSomeShit = Random.value >= 0.5f;

        if (shouldIDropSomeShit)
        {
            float whatTheFuckShouldIDrop = Random.value;

            GameObject clone;
            //HealthBox
            if(whatTheFuckShouldIDrop < 0.5)
            {
                clone = healthBox;
            }
            //AmmoBox
            else
            {
                clone = ammoBox;                
            }

            position.y = clone.transform.position.y;

            clone = Instantiate(clone, position, clone.transform.rotation) as GameObject;
            Destroy(clone, 10f);
        }
    }
}
