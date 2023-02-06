using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameModel gameModel;
	public GameView gameView;
	// public Enemy enemy;
	// public EnemyView enemyView;

	void Update()
	{
		Player();
		Enemy();
	}

	private void Player()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		gameModel.Move(horizontal, vertical);
		gameView.UpdateMovementAnimations(horizontal, vertical);
		gameView.UpdateVisualDirection(horizontal);
	}
	
	private void Enemy()
	{
		// enemy.Move();
		// enemyView.UpdateMovementAnimations();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			gameModel.PickUpItem();

		}

		// if (enemy.Attack())
		// {
		// 	player.TakeDamage(10);
		// 	enemyView.PlayAttackAnimation();
		// }
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		gameModel.PickUpItem();
		gameView.PlayPickUpSound();
		gameView.PickUpScore(gameModel.Score);
		
		Destroy(other.gameObject);
		
		if(gameModel.Score == 50f)
		{
			gameView.ShowWin();
		}
	}
	
	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}

