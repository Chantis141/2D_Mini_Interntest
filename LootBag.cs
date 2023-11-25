using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LootBag : MonoBehaviour
{
    public GameObject droppedItemGameObject;
    public List<Loot_Item> lootlist = new List<Loot_Item>();

     Loot_Item GetDroppItem()
    {
        int randomNumber = Random.Range(1,101 ); // 1-100
        List<Loot_Item> possibleItem = new List<Loot_Item>();
        foreach ( Loot_Item item in lootlist )
        {
            if(randomNumber <= item.dropchance )
            {
                possibleItem.Add(item);
                
            }
        }
        if( possibleItem.Count > 0 ) 
        {
            Loot_Item droppedItem = possibleItem[Random.Range(0,possibleItem.Count)];
            return droppedItem;
        }
        Debug.Log("No loot drop");
        return null;
    }



    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot_Item droppedItem = GetDroppItem();
        if(droppedItem != null )
        {
            GameObject lootGameObject = Instantiate(droppedItemGameObject, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.WeaponPre;

            //float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
            //lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce,ForceMode2D.Impulse);

        }
    }
}
