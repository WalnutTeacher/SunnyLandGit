using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject Item_FeedBack;

    public int score = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find("GameManager"))
            {
                GameManager._GameManager.score += score;
                GameManager._GameManager.score_count += 1;
            }

            AudioManager._AudioManager.SE_GetItem();

            Instantiate(Item_FeedBack, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
