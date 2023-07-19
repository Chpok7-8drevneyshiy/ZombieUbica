using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] float damage;
    [SerializeField] private float attackSpeed;
    GameObject _player;
    private float time;
    private Rigidbody rb;
    GameObject Player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0;
    }

    private void Update()
    {
        Player = GameObject.Find("player");
        player = Player.transform;
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f; 

            Vector3 movement = direction.normalized * speed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, toRotation, 360f));
            }
        }
        time += Time.deltaTime;


    }
    private void OnCollisionStay(Collision collision)
    {   
    if (collision.gameObject.name == "player")
        {
            _player = collision.gameObject;
                if (time > attackSpeed)
                {
                   _player.GetComponent<PlayerHp>().TakeDamage(damage);
                    time = 0;
                }      
        }
    }
}

