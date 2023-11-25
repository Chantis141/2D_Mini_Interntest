// Player_Interact.cs
using UnityEngine;
using UnityEngine.Events;

public class Player_Interact : MonoBehaviour
{
    public bool IsinRange;
    public KeyCode interactkey;
    public UnityEvent interactAction;

    private LootboxController lootboxController;
    private GameObject lootboxInstance;

    void Update()
    {
        if (IsinRange)
        {
            if (Input.GetKeyDown(interactkey) && lootboxController != null && lootboxInstance != null)
            {
                interactAction.Invoke();

                lootboxController.OpenBox();
                StartCoroutine(lootboxController.DestroyLootboxAfterDelay(lootboxInstance));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsinRange = true;
            Debug.Log("Player now in Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsinRange = false;
            Debug.Log("Player Exit Range");
        }
    }

    public void SetLootboxController(LootboxController lootboxController, GameObject lootboxInstance)
    {
        this.lootboxController = lootboxController;
        this.lootboxInstance = lootboxInstance;
    }
}
