using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 Move;
    private RoomBaseMono _currentRoom;
    private bool _isRotating = false;
    private bool _isWalking = false;

    [SerializeField] private float RotationTime = 0.4f;
    [SerializeField] private float WalkingTime = 1f;
    private float _rotationTimer;
    private Quaternion _previousRotation;
    private Direction _facingDirection;

    private Dictionary<Direction, int> _rotationByDirection = new()
   {
       { Direction.North, 0 },
       { Direction.East, 90 },
       { Direction.South, 180 },
       { Direction.West, 270 }
   };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup()
    {
        // simple array of all directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
        // roll random direction
        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        // Update transform
        SetFacingDirection();
    }
    // INPUT SYSTEM (Movement)
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }
    private void MoveInput(Vector2 directions)
    {
        if (_isWalking || _isRotating)
            return;
        Move = directions;
        if (directions.x < 0) TurnLeft();
        else if (directions.x > 0) TurnRight();
        else if (directions.y > 0) MoveForward();
    }
    private void TurnLeft()
    {
        if (_isRotating || _isWalking) return;
        _previousRotation = transform.rotation;
        _facingDirection = _facingDirection switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            _ => Direction.North
        };
        _isRotating = true;
    }
    private void TurnRight()
    {
        if (_isRotating || _isWalking) return;
        _previousRotation = transform.rotation;
        _facingDirection = _facingDirection switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            _ => Direction.North
        };
        _isRotating = true;
    }
    private void SetFacingDirection()
    {
        Vector3 facing = transform.rotation.eulerAngles;
        facing.y = _rotationByDirection[_facingDirection];
        transform.rotation = Quaternion.Euler(facing);
    }
    private void MoveForward()
    {
        if (_currentRoom == null) return;

        RoomBaseMono nextRoom = _currentRoom.GetRoom(_facingDirection);
        if (nextRoom == null)
        {
            Debug.Log("Blocked: No room ahead.");
            return;
        }
        StartCoroutine(WalkToRoom(nextRoom));
    }
    private IEnumerator WalkToRoom(RoomBaseMono nextRoom)
    {
        _isWalking = true;
        Vector3 start = new(transform.position.x, 1, transform.position.z);
        Vector3 end = new(nextRoom.transform.position.x, 1, nextRoom.transform.position.z);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / WalkingTime;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        _isWalking = false;
    }
    // ROOM DETECTION
    private void OnTriggerEnter(Collider col)
    {
        RoomBaseMono room = col.GetComponent<RoomBaseMono>();
        if (room != null)
        {
            _currentRoom = room;
            room.OnRoomEntered();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        RoomBaseMono room = col.GetComponent<RoomBaseMono>();
        if (room != null)
        {
            room.OnRoomExited();
        }
    }

    private void Update()
    {
        if (_isRotating)
        {
            Quaternion currentRotation = Quaternion.Lerp(_previousRotation, Quaternion.Euler(new Vector3(0, _rotationByDirection[_facingDirection])), _rotationTimer / RotationTime);
            transform.rotation = currentRotation;

            _rotationTimer += Time.deltaTime;
            if (_rotationTimer > RotationTime)
            {
                _isRotating = false;
                _rotationTimer = 0.0f;
                SetFacingDirection();
            }
        }
        // SEARCH ACTION
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (_currentRoom == null)
            {
                Debug.Log("You are not inside a room.");
                return;
            }

            // Base search
            _currentRoom.OnRoomSearched();

            // Room-specific search
            if (_currentRoom is IRoomAction actionRoom)
            {
                actionRoom.OnSearch();
            }
        }
    }
}