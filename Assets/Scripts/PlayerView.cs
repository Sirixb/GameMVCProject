using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
	public Animator animator;
	public AudioSource audioSource;
	public SpriteRenderer spriteRenderer;
	public Text scoreText;
	public GameObject winGameObject;
	public GameObject loseGameObject;
	

	public void UpdateMovementAnimations(float horizontal, float vertical)
	{
		animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
		animator.SetFloat("Vertical", Mathf.Abs(vertical));
	}

	public void UpdateVisualDirection(float horizontal)
	{
		if(horizontal < 0)
		{
			spriteRenderer.flipX= true;
		}
		else if(horizontal > 0)
		{
			spriteRenderer.flipX= false;
		}
	}

	public void PlayPickUpSound()
	{
		audioSource.Play();
	}
	
	public void PickUpScore(int score)
	{
		scoreText.text = score.ToString();
	}

	public void Win()
	{
		winGameObject.SetActive(true);
	}
	
	public void Lose()
	{
		loseGameObject.SetActive(true);
	}
}


