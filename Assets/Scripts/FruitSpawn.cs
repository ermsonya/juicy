using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> fruitPrefabs;
    [SerializeField] private List<Collider2D> groundColliders;

    public float fruitSpeed = 9;
    public float maxDistance = 2f;
    public float fruitCooldown = 0.75f;

    private Camera _mainCamera;

    private List<GameObject> _fruitsList = new List<GameObject>();
    private GameObject _mainFruit;
    private Rigidbody2D _fruitRigidbody2D;
    private Transform _fruitTransform;
    private int _fruitIndex = 1;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 _fruitDirection;

    private bool _isPressed;
    private bool _isCooldown;
    private bool _firstSpawn = true;
    private IEnumerator _coroutine;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (SceneManagment.isGameStarted)
        {
            if (!_firstSpawn)
            {
                SelectFruit();
                FruitMove();
            }
            else
            {
                SpawnFruit(1);
                _firstSpawn = false;
            }
        }
        
        foreach (GameObject fruit in _fruitsList.ToList())
        {
            if (groundColliders.Any(groundCollider => fruit.GetComponent<Collider2D>().IsTouching(groundCollider)))
            {
                DeleteFruit(fruit);
            }
        }
    }

    private void SelectFruit()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!_isCooldown)
                DeleteFruit(_mainFruit);
            else
                StopCoroutine(_coroutine);

            _fruitIndex = 0;
            SpawnFruit(_fruitIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!_isCooldown)
                DeleteFruit(_mainFruit);
            else
                StopCoroutine(_coroutine);

            _fruitIndex = 1;
            SpawnFruit(_fruitIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!_isCooldown)
                DeleteFruit(_mainFruit);
            else
                StopCoroutine(_coroutine);

            _fruitIndex = 2;
            SpawnFruit(_fruitIndex);
        }
    }

    public void DeleteFruit(GameObject fruit)
    {
        Destroy(fruit);
        _fruitsList.Remove(fruit);
    }

    private void SpawnFruit(int fruitIndex)
    {
        _mainFruit = Instantiate(fruitPrefabs[fruitIndex], transform.position, Quaternion.identity);

        _fruitRigidbody2D = _mainFruit.GetComponent<Rigidbody2D>();
        _fruitRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;

        _fruitTransform = _mainFruit.transform;

        _fruitsList.Add(_mainFruit);
    }

    private IEnumerator SpawnFruitCooldown(int fruitIndex)
    {
        yield return new WaitForSeconds(fruitCooldown);
        SpawnFruit(fruitIndex);
    }

    private IEnumerator SetCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(fruitCooldown);
        _isCooldown = false;
    }

    private void FruitMove()
    {
        if (_isCooldown)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _startPos = GetMousePosition();
            _isPressed = true;
        }

        if (_isPressed)
        {
            Vector3 pos = GetMousePosition();
            _fruitDirection = pos - _startPos;

            if (_fruitDirection.magnitude <= maxDistance)
                _fruitTransform.position = transform.position + pos - _startPos;
            else
                _fruitTransform.position = transform.position + (pos - _startPos).normalized * maxDistance;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && _isPressed)
        {
            _isPressed = false;
            _endPos = GetMousePosition();

            if (_fruitDirection.magnitude < maxDistance)
                _fruitDirection = _endPos - _startPos;
            else
                _fruitDirection = (_endPos - _startPos).normalized * maxDistance;

            _fruitRigidbody2D.constraints = RigidbodyConstraints2D.None;
            Debug.Log(_startPos + " a " + _endPos);
            _fruitRigidbody2D.AddForce(-_fruitDirection * fruitSpeed, ForceMode2D.Impulse);

            _coroutine = SpawnFruitCooldown(_fruitIndex);
            StartCoroutine(_coroutine);
            StartCoroutine(SetCooldown());

            _fruitDirection = Vector3.zero;
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;

        return position;
    }
}