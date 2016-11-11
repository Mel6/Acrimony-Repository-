using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerBullet : MonoBehaviour
{

	private Player player;
    private float Speed;
    private Rigidbody2D _bulletBody;

    // Run once
    void Start()
    {
        _bulletBody = GetComponent<Rigidbody2D>();
        Speed = 5;
    }

    void Update()
    {
		MoveBullet();
    }


	//Have the bullet move in space
    public void MoveBullet()
    { 
		var playerPos = player.transform.localScale;

		_bulletBody.velocity = new Vector2(Speed, 0);
    }
}