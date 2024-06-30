using System.Runtime.CompilerServices;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] float jumpHeight = 5;
    private bool _wstrzymana;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector3 direction;
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        GoToStart();
    }
    public void GoToStart()
    {
        rigidbody2D.velocity = Vector2.zero;
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
           rigidbody2D.velocity = Vector2.up * jumpHeight;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _wstrzymana = !_wstrzymana;
            if(_wstrzymana)
            {
                GameManager.Instance.PauzaGry();
                AudioListener.pause = true;
            }
            else
            {
                GameManager.Instance.WznowienieGry();
                AudioListener.pause = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("zgon")) {
            GameManager.Instance.GameOver();
        } else if (other.gameObject.CompareTag("punkt")) {
            GameManager.Instance.IncreaseScore();
        }
    }
}

