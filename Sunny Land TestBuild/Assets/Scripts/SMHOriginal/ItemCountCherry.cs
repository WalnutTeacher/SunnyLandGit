using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCountCherry : MonoBehaviour
{
    public GameObject Item_FeedBack;

    public int score = 1000;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find("GameManager"))
            {
                GameManager._GameManager.collectibles_count += 1;

                GameManager._GameManager.score += score;
            }

            AudioManager._AudioManager.SE_GetItem();

            Instantiate(Item_FeedBack, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
