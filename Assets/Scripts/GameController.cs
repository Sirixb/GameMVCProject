using UnityEngine;

public class GameController : MonoBehaviour
{
	public PlayerModel playerModel;
	public PlayerView playerView;
	// public Enemy enemy;
	// public EnemyView enemyView;

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		playerModel.Move(horizontal, vertical);
		playerView.UpdateMovementAnimations(horizontal, vertical);
		playerView.UpdateVisualDirection(horizontal);
		// enemy.Move();
		// enemyView.UpdateMovementAnimations();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			playerModel.PickUpItem();
			playerView.PlayPickUpSound();
		}

		// if (enemy.Attack())
		// {
		// 	player.TakeDamage(10);
		// 	enemyView.PlayAttackAnimation();
		// }
	}
}
