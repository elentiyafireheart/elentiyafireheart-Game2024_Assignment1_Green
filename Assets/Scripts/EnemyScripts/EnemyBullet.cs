using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float Speed;
    ScoreScript _scoreScript;
    public AudioClip collisionSound;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _scoreScript = FindObjectOfType<ScoreScript>();
        GetComponent<AudioSource>().clip = collisionSound;
    }

    void Update()
    {
        _rigidbody.velocity = Vector2.down * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerTag"))
        {
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}