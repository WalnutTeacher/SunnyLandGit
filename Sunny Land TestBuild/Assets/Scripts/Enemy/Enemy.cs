using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Enemy_Death;

    public int score = 1000;

    public void Death()
    {
        GameManager._GameManager.score += score;
        GameManager._GameManager.monster_count += 1;
        Instantiate(Enemy_Death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
