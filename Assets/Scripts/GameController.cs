using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameModel gameModel;
	public GameView gameView;

	private void Start()
	{
		InvokeRepeating("Enemy", 2.5f, 2);
	}
	
	void Update()
	{
		Player();
		gameModel.EnemyIABullet();
	}

	private void Player()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		gameModel.PlayerMove(horizontal, vertical);
		gameView.UpdateMovementAnimations(horizontal, vertical);
		gameView.UpdateVisualDirection(horizontal);
	}
	
	public void Enemy()
	{
		gameModel.EnemyAttack();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		gameModel.PickUpItem();
		gameView.PlayPickUpSound();
		gameView.PickUpScore(gameModel.score);
		
		Destroy(other.gameObject);
		
		if(gameModel.score == 50f)
		{
			gameView.ShowWin();
			CancelInvoke();
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log(other.collider.name);
		if(other.collider.name == "slimer8(Clone)")
		{
			gameModel.TakeDamage(1);
			gameView.HurtAnimation();
			Destroy(other.gameObject);
			
			if(gameModel.health <= 0f)
			{
				gameView.Die();
				gameView.ShowLose();
				CancelInvoke();
			}
		}
	}
	
	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}

