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
                Vector2 coords = new Vector2(x * RoomSize, z * RoomSize);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);

                roomInstance.transform.position = coords;

                _map[x, z] = roomInstance;
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

