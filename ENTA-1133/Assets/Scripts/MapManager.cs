using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBaseMono[] RoomPrefabs;
    [SerializeField] private float RoomSize = 1;
    [SerializeField] private int MapSize = 3;
    private RoomBaseMono[,] _map;

    public RoomBaseMono GetRoomAt(int x, int z) {
        if (x < 0 || x > _map.GetLength(1) - 1 || z < 0 || z > _map.GetLength(0) - 1)
            return null;
        return _map[z, x];
    }

    public void CreateMap()
    {
        _map = new RoomBaseMono[MapSize, MapSize];
        for (int z = 0; z < MapSize; z++)
        {
            for (int x = 0; x < MapSize; x++)
            {
                Vector3 coords = new Vector3(x * RoomSize, 3, -z * RoomSize);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);

                roomInstance.name += $"[{x},{z}]";
                roomInstance.transform.position = coords;

                _map[z, x] = roomInstance;
            }
        }
        for (int z = 0; z < MapSize; z++)
        {
            for (int x = 0; x < MapSize; x++)
            {
                RoomBaseMono currentRoom = _map[z, x];
                RoomBaseMono north = null, south = null, east = null, west = null;
                north = GetRoomAt(x, z - 1);
                south = GetRoomAt(x, z + 1);
                east = GetRoomAt(x + 1, z);
                west = GetRoomAt(x - 1, z);
                currentRoom.SetRooms(north, east, south, west);
            }
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

