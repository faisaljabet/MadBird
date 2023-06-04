using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyCat : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _catWasLaunched;

    [SerializeField] private float _launchPower = 250;
    private float _timeSittingAround;


    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);


        if (_catWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 100 ||
            transform.position.y < -100 ||
            transform.position.x > 100 ||
            transform.position.x < -100 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 diractionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(diractionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _catWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
