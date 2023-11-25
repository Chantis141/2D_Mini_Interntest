using UnityEngine;

public class Lootbox_Animation : MonoBehaviour
{
    public bool isOpen;
    public Animator anim;

    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("IS OPEN");
            anim.SetBool("IsOpen", isOpen);
        }
    }
    
}
