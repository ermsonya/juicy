using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> fruitPrefabs;
    [SerializeField] private List<Collider2D> groundColliders;

    public float fruitSpeed = 4;

    private Camera _mainCamera;

    private GameObject _mainFruit;
    private Rigidbody2D _fruitRigidbody2D;
    private Collider2D _fruitCollider2D;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private int _fruitIndex = 1;
    private bool _isPressed;
    private bool _isFly;

    void Start()
    {
        _mainCamera = Camera.main;

        SpawnFruit(1);
    }

    void Update()
    {
        SelectFruit();
        FruitMove();

        if (groundColliders.Any(groundCollider => _fruitCollider2D.IsTouching(groundCollider)))
        {
            DeleteFruit();
            SpawnFruit(_fruitIndex);
        }
    }

    private void SelectFruit()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeleteFruit();

            _fruitIndex = 0;
            SpawnFruit(_fruitIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeleteFruit();

            _fruitIndex = 1;
            SpawnFruit(_fruitIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DeleteFruit();

            _fruitIndex = 2;
            SpawnFruit(_fruitIndex);
        }
    }

    private void DeleteFruit()
    {
        Destroy(_mainFruit);
        _isFly = false;
    }

    private void SpawnFruit(int fruitIndex)
    {
        _mainFruit = Instantiate(fruitPrefabs[fruitIndex], transform.position, Quaternion.identity);

        _fruitRigidbody2D = _mainFruit.GetComponent<Rigidbody2D>();
        _fruitRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;

        _fruitCollider2D = _mainFruit.GetComponent<Collider2D>();
    }

    private void FruitMove()
    {
        if (_isFly)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _startPos = GetMousePosition();
            _isPressed = true;
        }

        if (_isPressed)
        {
            Vector3 pos = GetMousePosition();
            _mainFruit.transform.position = pos;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _isPressed = false;
            _isFly = true;
            _endPos = GetMousePosition();

            Vector3 direction = _endPos - _startPos;

            _fruitRigidbody2D.constraints = RigidbodyConstraints2D.None;
            _fruitRigidbody2D.AddForce(-direction * fruitSpeed, ForceMode2D.Impulse);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;

        return position;
    }
}