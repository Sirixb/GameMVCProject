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
		gameView.PlayEnemyAttackSound();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Cherry"))
		{
			PickupFruit();
			Destroy(other.gameObject);
		}

		if (IsWin())
		{
			gameView.ShowWin();
			gameModel.capsuleCollider2DPlayer.enabled = false;
			CancelInvoke();
		}
	}

	private void PickupFruit()
	{
		gameModel.PickUpItem();
		gameView.PlayPickUpSound();
		gameView.PickUpScore(gameModel.score);
	}

	private bool IsWin()
	{
		return gameModel.score == 100f;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{

		if (IsEnemyBullet(other))
		{
			UpdateHealth();
			Destroy(other.gameObject);

			if (IsDie())
			{
				gameModel.capsuleCollider2DPlayer.enabled = false;
				gameView.Die();
				gameView.ShowLose();
				CancelInvoke();
			}
		}
	}

	private static bool IsEnemyBullet(Collision2D other)
	{
		return other.collider.name == "slimer8(Clone)";
	}

	private void UpdateHealth()
	{
		gameModel.TakeDamage(1);
		gameView.HealthIcon(gameModel.health);
		gameView.HurtAnimation();
		gameView.HurtPlayerSound();
	}

	private bool IsDie()
	{
		return gameModel.health <= 0f;
	}
	
	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}

