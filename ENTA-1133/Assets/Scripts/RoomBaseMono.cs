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
    public RoomBaseMono GetRoom(Direction direction)
    {
        return direction switch
        {
            Direction.North => _north,
            Direction.East => _east,
            Direction.South => _south,
            Direction.West => _west,
            _ => null
        };
    }
    public void OnRoomEntered()
    {
        Debug.Log($"Entered room: {name}");
    }
    public void OnRoomExited()
    {
        Debug.Log($"Exited room: {name}");
    }
    public void OnRoomSearched()
    {
        Debug.Log($"Searching room: {name}");
    }
}
