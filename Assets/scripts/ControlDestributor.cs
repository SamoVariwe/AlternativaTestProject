using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class ControlDestributor : MonoBehaviour
{

    private ControlDestributor() {
        instance = this;
        
    }

    static private ControlDestributor instance;

    public static ControlDestributor Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new ControlDestributor();
                
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject Player;

    private PlayerController playerController;

    [SerializeField]
    private GameObject Ship;

    [SerializeField]
    private Camera mainCamera;

    private FollowingObject followingCamera;



    private ShipController shipController;

    void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
        shipController = Ship.GetComponent<ShipController>();
        followingCamera = mainCamera.GetComponent<FollowingObject>();
    }


    public void PlayerControllerSwitch(bool Enable)
    {
        if(Enable)
        playerController.enabled = true;
        else playerController.enabled = false;
        
    }

    public void ShipControllerSwitch(bool Enable)
    {
        if (Enable)
            shipController.enabled = true;
        else shipController.enabled = false;
    }

    public void SwitchShipPlayerControll()
    {
        
        playerController.enabled = !playerController.enabled;
        shipController.enabled = !shipController.enabled;
    }

    public void SwitchPlayerShipCamera()
    {
        if (playerController.enabled)
        {
            followingCamera.SnapCameraToObject(Ship);

        }
        else followingCamera.SnapCameraToObject(Player);
    }

    public void SwitchPlayerShip()
    {
        SwitchPlayerShipCamera();
        SwitchShipPlayerControll();

    }
}
