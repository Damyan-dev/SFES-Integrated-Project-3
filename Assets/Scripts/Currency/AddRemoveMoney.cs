using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRemoveMoney : MonoBehaviour
{
    public GameObject camera;
    public GameObject canvasObject;

    // Start is called before the first frame update
    void Start()
    {
       canvasObject.SetActive(false);
    }

    public void Subtract10()
    {
        ItemData item = InventoryManager.Instance.ItemSearch("Cotton Seeds");
        
        
            InventoryManager.Instance.ItemAdd(item);
            camera.GetComponent<playerMoney>().subtractMoney(10);
        
    }

    public void Subtract25()
    {
        camera.GetComponent<playerMoney>().subtractMoney(25);
    }
    public void Subtract100()
    {
        camera.GetComponent<playerMoney>().subtractMoney(100);
    }
    public void Add30()
    {
        ItemData item = InventoryManager.Instance.ItemSearch("Rare Shirt");
        if (item != null)
        {
            InventoryManager.Instance.ItemRemove(item);
            camera.GetComponent<playerMoney>().addMoney(30);
        }
    }
    public void Add50()
    {
        ItemData item = InventoryManager.Instance.ItemSearch("Dyed Shirt");
        if (item != null)
        {
            InventoryManager.Instance.ItemRemove(item);
            camera.GetComponent<playerMoney>().addMoney(50);
        }
    }

    public void ShopkeeperOn()
    {
        canvasObject.SetActive(true);

    }
    public void ShopkeeperOff()
    {
        canvasObject.SetActive(false);
    }

    /*public void ShearSheep()
    {
       //  ItemData item = Wool;
  
             InventoryManager.Instance.ItemAdd(item);
        
    } */
}
