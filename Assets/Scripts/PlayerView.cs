using UnityEngine;

public class PlayerView : MonoBehaviour
{
	public Animator animator;
	public AudioSource audioSource;
	public SpriteRenderer spriteRenderer;

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
}


