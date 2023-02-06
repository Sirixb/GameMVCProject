using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
	public int Health { get; set; }
	public int Score { get; set; }
	
	public Rigidbody2D rigidbody2DPlayer;
	private Vector2 movement;
	private float velocity = 5f;
	
	
	public void Move(float horizontal, float vertical)
	{
		movement= new Vector2(horizontal,vertical);
		rigidbody2DPlayer.velocity= movement * velocity;
	}
	
	public void PickUpItem()
	{
		Score+= 10;
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
	}
}

