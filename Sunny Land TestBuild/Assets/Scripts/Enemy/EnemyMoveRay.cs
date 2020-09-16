using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRay : MonoBehaviour
{
    public float moving_speed;
    RaycastHit2D[] ray_hit = new RaycastHit2D[3];
    SpriteRenderer _SpriteRenderer;
    int direction = 1;
    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moving_speed * Time.deltaTime, 0, 0);
        RaycastHit2D ray_hit = Physics2D.Raycast(new Vector2(transform.position.x + direction, transform.position.y), Vector3.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        Debug.DrawRay(new Vector2(transform.position.x + direction, transform.position.y), Vector3.down);
        if (ray_hit.collider == null)
        {
            direction = direction * (-1);
            moving_speed = moving_speed * (-1);
            if (_SpriteRenderer.flipX)
                _SpriteRenderer.flipX = false;
            else
                _SpriteRenderer.flipX = true;
        }
    }
}
