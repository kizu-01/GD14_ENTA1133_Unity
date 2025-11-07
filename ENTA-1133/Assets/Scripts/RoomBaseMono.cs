using Unity.VisualScripting;
using UnityEngine;

public class RoomBaseMono : MonoBehaviour
{
    [SerializeField] private GameObject NorthDoorway, EastDoorway, SouthDoorway, WestDoor;
    private RoomBaseMono _north, _south, _east, _west;

    public void SetRooms(RoomBaseMono roomNorth, RoomBaseMono roomEast, RoomBaseMono roomSouth, RoomBaseMono roomWest)
    {
        _north = roomNorth;
        NorthDoorway.SetActive(_north == null);
        _east = roomEast;
        EastDoorway.SetActive(_east == null);
        _south = roomSouth;
        SouthDoorway.SetActive(_south == null);
        _west = roomWest;
        WestDoor.SetActive(_west == null);
    }
}
