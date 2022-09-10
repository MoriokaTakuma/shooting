using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_Sphere : MonoBehaviour
{
	/// <summary>
	/// 衝突対象のオブジェクト
	/// </summary>
	[SerializeField]
	private GameObject[] objects_;

	/// <summary>
	/// 更新処理
	/// </summary>
	private void FixedUpdate()
	{
		var sphere1 = objects_[0];
		var sphere2 = objects_[1];

		// 二つの位置の距離を計算する
		var length = (sphere1.transform.position - sphere2.transform.position).magnitude;

		// 球1の半径
		var radius1 = 0.5f;
		// 球2の半径
		var radius2 = 0.5f;

		// 二つの半径を足した長さ
		var checkLength = radius1 + radius2;

		// 点同士の距離が二つの球の半径の合計より短いなら衝突している
		if (length <= checkLength)
		{
			Destroy(gameObject);
		}
		//else
		//{
		//	sphere2.GetComponent<MeshRenderer>().materials[0].color = Color.white;
		//}
	}
}
