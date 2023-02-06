using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
	
	[Header("Player")]
	public Rigidbody2D rigidbody2DPlayer;
	public int health = 3;
	public int score = 0;
	private float playerVelocity = 5f;
	private Vector2 movement;
	
	[Header("Enemy")]
	public GameObject bullet;
	public Transform bulletSpawn;
	public float enemyVelocityAttack = 5f;
	private GameObject bulletInstance;
	
	public void PlayerMove(float horizontal, float vertical)
	{
		movement= new Vector2(horizontal,vertical);
		rigidbody2DPlayer.velocity= movement * playerVelocity;
	}
	
	public void PickUpItem()
	{
		score+= 10;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}
	
	public void EnemyAttack()
	{
		bulletInstance = Instantiate(bullet,bulletSpawn.position,Quaternion.identity);
	}
	
	public void EnemyIABullet()
	{
		// enemy.Move();
		// enemyView.UpdateMovementAnimations();

		Vector2 directionToPlayer = transform.position - bulletSpawn.position;

		if(bulletInstance != null)
		{
			bulletInstance.transform.Translate((directionToPlayer.normalized * enemyVelocityAttack) * Time.deltaTime);
			Destroy(bulletInstance, 4f);
		}
		// if (enemy.Attack())
		// {
		// 	player.TakeDamage(10);
		// 	enemyView.PlayAttackAnimation();
		// }
	}
}

