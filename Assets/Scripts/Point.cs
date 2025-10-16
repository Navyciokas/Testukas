using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    public TextMeshPro scoreTxt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreTxt.text = (int.Parse(scoreTxt.text)+1).ToString();
            Destroy(gameObject);
            AudioManager.Instance.PlayScore();
        }
    }
}

