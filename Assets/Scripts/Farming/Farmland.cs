using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmland : MonoBehaviour, ITimeTracker
{
    public GameObject selected;
    public GameObject cottonCrop;
    public GameObject cottonDrop;
    public Transform dropPosition;
    public Material dirtMat, farmMat, wateredMat;
    public GameTimeConverter timeWatered;
    

    public enum FarmStatus
    {
        Dirt, Farm, Watered
    }
    public FarmStatus farmStatus;

    private new Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        ChangeFarmStatus(FarmStatus.Dirt);
        Selected(false);
        TimeController.Instance.InitTracker(this);
    }

    public void ChangeFarmStatus(FarmStatus farmToSwitch)
    {
        farmStatus = farmToSwitch;
        Material materialToSwitch = dirtMat;

        switch (farmToSwitch)
        {
            case FarmStatus.Dirt:
                materialToSwitch = dirtMat;
                break;
            case FarmStatus.Farm:
                materialToSwitch = farmMat;
                Destroy(cottonCrop);
                Instantiate(cottonDrop, dropPosition.position, dropPosition.rotation);
                break;
            case FarmStatus.Watered:
                materialToSwitch = wateredMat;

                timeWatered = TimeController.Instance.GetTimeStamp();
                break;
        }

        renderer.material = materialToSwitch;
    }

    public void Selected(bool toggle)
    {
        selected.SetActive(toggle);
    }

    public void Interact()
    {
        ChangeFarmStatus(FarmStatus.Farm);
    }

    public void ClockUpdate(GameTimeConverter gametime)
    {
        if(farmStatus == FarmStatus.Watered)
        {
            int hoursPassed = GameTimeConverter.CompareTime(timeWatered, gametime);
            Debug.Log(hoursPassed + " since the crop was watered.");

            if(hoursPassed > 24)
            {
                ChangeFarmStatus(FarmStatus.Farm);
            }
        }
    }
}
