using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterTrigger : MonoBehaviour
{
    Monster EnemyClass => (transform.parent.GetComponent<Monster>());

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemyClass.PlayerTransform = collision.GetComponent<Transform>();
            EnemyClass.isFindPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyClass.PlayerTransform = null;
        EnemyClass.isFindPlayer = false;
    }
}
