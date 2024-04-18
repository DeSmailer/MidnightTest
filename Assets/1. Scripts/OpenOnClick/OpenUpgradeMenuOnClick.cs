using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeMenuOnClick : OpenOnClick
{
    [SerializeField] protected HobUpgradeView _hobUpgradeView;
    [SerializeField] protected MainHob _mainHob;

    public override void Open()
    {
        _hobUpgradeView.Open();
        _hobUpgradeView.Initialize(_mainHob);
    }
}
