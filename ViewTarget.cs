using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTarget : MonoBehaviour
{

	/// <summary>
	/// ターゲット
	/// </summary>
	[SerializeField]
	private GameObject target_;


	/// <summary>
	/// 更新処理
	/// </summary>
	void Update()
	{
		
		
			// ターゲットまでの向きの単位ベクトル
			var toTarget = (target_.transform.position - transform.position).normalized;
			// 自身の前方を指す単位ベクトル
			var fowerd = transform.forward;

			// 単位ベクトル同士の内積で cos を求める
			var dot = Vector3.Dot(fowerd, toTarget);
			// cos から角度（ラジアン）を求める
			var radian = Mathf.Acos(dot);

			// 外積で回転軸を求める
			var cross = Vector3.Cross(fowerd, toTarget);			

			// 回転軸が上向きか下向きかで角度を反転させる
			radian *= (cross.y / Mathf.Abs(cross.y));

			// 角度を指定して回転させる
			transform.rotation *= Quaternion.Euler(0, Mathf.Rad2Deg * radian, 0);
		
	}

}
