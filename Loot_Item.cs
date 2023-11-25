using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot_Item : ScriptableObject
{
    public Sprite WeaponPre;
    public string lootname;
    public int dropchance;
    
    public Loot_Item(string lootname, int dropchance)
    {
        this.lootname = lootname;
        this.dropchance = dropchance; 
    }
}
