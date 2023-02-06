using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameView : MonoBehaviour
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

	public void PlayEnemyAttackSound()
	{
		audioSource.Play();
	}
	
	public void ShowWin()
	{
		winGameObject.SetActive(true);
	}
	
	public void ShowLose()
	{
		loseGameObject.SetActive(true);
	}

	public void HurtAnimation()
	{
		animator.SetTrigger("Hurt");
	}

	public void Die()
	{
		animator.SetBool("Die", true);
	}
	
	public void DeactivatePlayer()
	{
		gameObject.SetActive(false);
	}
}


