using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisperseCloud : MonoBehaviour {

    bool finished; 

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 6f;
    private float startTime;

    public SpriteRenderer sprite;

    private void Awake()
    {
        finished = true;
    }

    private void Update()
    {
        if (!finished) {
            FadeSprite();
            if (sprite.color.a == 0) {
                finished = true;
                Invoke("DestroyObj", 4);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player") {
            Puff();
        }
    }

    void Puff() {
        ParticleSystem part = GetComponent<ParticleSystem>();
        startTime = Time.time;
        part.Play();
        finished = false;
    }

    void FadeSprite() {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    } 
}