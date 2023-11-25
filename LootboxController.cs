// LootboxController.cs
using UnityEngine;
using System.Collections;

public class LootboxController : MonoBehaviour
{
    public GameObject lootboxPrefab;
    public GameObject lootItemPrefab;
    public Transform lootSpawnPoint;
    [SerializeField] private AudioSource OpenChest;

    private bool isBoxOpened = false;

    void Start()
    {
        Debug.Log("Spawning Lootbox");
        SpawnLootbox();
    }

    void SpawnLootbox()
    {
        
        
            Vector2 randomPosition = GetRandomPosition();
            GameObject lootboxInstance = Instantiate(lootboxPrefab, randomPosition, Quaternion.identity);

            lootSpawnPoint = lootboxInstance.transform;
            Player_Interact playerInteract = FindObjectOfType<Player_Interact>();
            playerInteract.SetLootboxController(this, lootboxInstance);

             //ตั้งค่าให้กล่องเริ่มแบบปิด
            isBoxOpened = false;
        
    }

    public IEnumerator DestroyLootboxAfterDelay(GameObject lootboxInstance)
    {
        // รอเปิดกล่อง
        yield return new WaitUntil(() => isBoxOpened);

        Debug.Log("Destroying lootboxInstance");

        // สร้างไอเทม
        LootBag lootBag = lootboxInstance.GetComponent<LootBag>();
        if (lootBag != null)
        {
            lootBag.InstantiateLoot(lootSpawnPoint.position);
        }

        // รอเวลา 5 วินาที
        yield return new WaitForSeconds(5f);

        // ทำลายกล่อง
        Destroy(lootboxInstance);

        SpawnLootbox();
        Debug.Log("Respawn");
    }

    private Vector2 GetRandomPosition()
    {
        float x, y;
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            x = Random.Range(5f, 20f);
            y = Random.Range(-3.433521f, -3.433521f);

            if (!IsTrapNearby(x, y))
            {
                return new Vector2(x, y);
            }
        }

        Debug.LogError("Cannot find a suitable position for Loot Box.");
        return Vector2.zero;
    }

    private bool IsTrapNearby(float x, float y)
    {
        float radius = 1.0f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(x, y), radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Trap"))
            {
                return true;
            }
        }

        return false;
    }

    public void OpenBox()
    {
        isBoxOpened = true;
        if(isBoxOpened)
        {
            OpenChest.Play();
        }
    }
}
