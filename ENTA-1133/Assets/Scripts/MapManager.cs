using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBaseMono[] RoomPrefabs;
    [SerializeField] private float RoomSize = 1;
    [SerializeField] private int MapSize = 3;
    private RoomBaseMono[,] _map;

    public void CreateMap()
    {
        _map = new RoomBaseMono[MapSize, MapSize];
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                Vector3 coords = new Vector3(x * RoomSize, 3, z * RoomSize);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);

                roomInstance.transform.position = coords;

                _map[x, z] = roomInstance;
            }
        }
        for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
                RoomBaseMono currentRoom = _map[x, z];
                RoomBaseMono north = null, south = null, east = null, west = null;
                if (x > 0) east = _map[x - 1, z];
                if (x < MapSize - 1) west = _map[x + 1, z];
                if (z > 0) north = _map[x, z - 1];
                if (z < MapSize - 1) south = _map[x, z + 1];
                currentRoom.SetRooms(north, south, east, west);
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

