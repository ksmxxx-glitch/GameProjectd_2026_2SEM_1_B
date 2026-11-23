using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 30;            // 초기 최대 체력

    [SerializeField] private int currentHealth;                              // 현재 잔여 체력


    [SerializeField] private GameObject dropItemPrefab;

    [SerializeField] private Vector3 dropOffset = new Vector3 (0f, 0.5f, 0f);

    private bool isDead;

    void Start()

    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)                      // 외부에서 피해를 전달받는 함수
    {

        if (isDead) return;

        currentHealth -= damage;
        Debug.Log(name + " 남은 체력 : " + currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        isDead = true;

        if (dropItemPrefab != null)
        {
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }


}
