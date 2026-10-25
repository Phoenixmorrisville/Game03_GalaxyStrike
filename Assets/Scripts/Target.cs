
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float score;
    [SerializeField] GameObject boomVFX;
    [SerializeField] ScoreManager scoreManager;

    private int currentHealth;

    void Awake()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            ExecuteDeath();
        }
    }

    void ExecuteDeath()
    {
        scoreManager.AddScore((int)score);
        Instantiate(boomVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void ResetTarget()
    {
        currentHealth = health;
        gameObject.SetActive(true);
    }
}
