using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 15f;
    private float inputX, inputY;
    private const string COLLECTIBLE_TAG = "Collectible";
    private const string FALLOFFAREA_TAG = "FallOffArea";

    [SerializeField] private Transform resetPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(inputX, 0, inputY) * moveSpeed);
        
        if (Input.GetKey(KeyCode.Space)) {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == COLLECTIBLE_TAG) {
            GameManager.Instance.addScore();
            Destroy(other.gameObject);
        }else if (other.gameObject.tag == FALLOFFAREA_TAG) {
            gameObject.transform.position = resetPoint.position;
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
    }
}