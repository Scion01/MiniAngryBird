using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{

    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;
    [SerializeField] private float _launchMagnitude = 600;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10 || 
            transform.position.x > 30 || 
            transform.position.y < -10 || 
            transform.position.x < -20||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        //v2-v1
        Vector2 directionToInitPosi = _initialPosition - transform.position;
        //addForce takes a vector with mag(vector for direction)
        GetComponent<Rigidbody2D>().AddForce(directionToInitPosi * _launchMagnitude);
        //and once we know where to push this rb we then renable gravity
        GetComponent<Rigidbody2D>().gravityScale = 1;
        //set the bool
        _birdWasLaunched = true;
        _timeSittingAround = 0;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 aPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aPositon.z = 0;
        transform.position = aPositon;
    }
}
