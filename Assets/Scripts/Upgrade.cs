using System.Collections;
using System.Collections.Generic;
using CatDefense;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{

	[SerializeField] private Upgrade[] _nextUpgrades;
	public Upgrade[] NextUpgrades
	{
		get { return _nextUpgrades; }
	}

	[SerializeField] private Sprite _icon;
	public Sprite Icon
	{
		get { return _icon; }
	}

	[SerializeField] private TowerWeapon _weapon;
	public TowerWeapon Weapon
	{
		get { return _weapon; }
	}
}
