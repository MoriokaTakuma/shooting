using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLine : MonoBehaviour
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
		var line	= objects_[0];
		var cube	= objects_[1];

		// 線の始点と終点(線の長さは10)
		var lineLenght = 10.0f;
		var start = line.transform.position;

		// AABBの中心と線上の最短位置を計算する
		var lineStartToSphereCenter = cube.transform.position - start;
		// 内積を計算して最短位置までの割合を計算する
		var dot = Vector4.Dot(lineStartToSphereCenter, line.transform.forward);
		// 線分の範囲内に収める
		dot = Mathf.Clamp(dot, 0, lineLenght);

		// 点と線上の最短位置を計算する
		var point = (line.transform.forward * dot) + start;

		// AABBの中心と線上の最短位置までの各軸の距離を計算する
		var length = new Vector3(
			Mathf.Abs(point.x - cube.transform.position.x),
			Mathf.Abs(point.y - cube.transform.position.y),
			Mathf.Abs(point.z - cube.transform.position.z)
			);

		// 各辺の半分の長さ
		var checkLength = cube.transform.localScale * 0.5f;

		// 各軸毎の距離が、全ての辺の半分の長さより短い場合は衝突している
		if (length.x <= checkLength.x && length.y <= checkLength.y && length.z <= checkLength.z)
		{
			cube.GetComponent<MeshRenderer>().materials[0].color = Color.red;
		}
		else
		{
			cube.GetComponent<MeshRenderer>().materials[0].color = Color.white;
		}
	}
}
