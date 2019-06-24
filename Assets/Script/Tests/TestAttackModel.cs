using System;
using System.Collections.Generic;
using UnityEngine;

//public class TestAttackModel : AttackModel
//{
//    public TestAttackModel(string setName, int setDamage, Vector2 setRange, float setRadius, int setAPCost) : base(setName, setDamage, setRange, setRadius, setAPCost)
//    {
//    }

//    //private Vector2 _range;
//    //public override Vector2 range => _range;

//    //private float _radius;
//    //public override float radius => _radius;

//    //private Dictionary<AttackType, bool> _matrix;
//    //public override Dictionary<AttackType, bool> Matrix => _matrix;

//    //public TestAttackModel(Vector2 range, float radius)
//    //{
//    //    _range = range;
//    //    _radius = radius;
//    //    _matrix = new Dictionary<AttackType, bool>()
//    //    {
//    //        { AttackType.Zone, true },
//    //        { AttackType.Position, false }
//    //    };
//    //    //_attackType = attackType;
//    //    Debug.Log(String.Format("Nouvelle abilité instanciée avec {0} de range", range.magnitude));
//    //}
//    public override void AttackExecute()
//    {
//        base.AttackExecute();
//    }

//    public override bool Equals(object other)
//    {
//        return base.Equals(other);
//    }

//    public override int GetHashCode()
//    {
//        return base.GetHashCode();
//    }

//    public override string ToString()
//    {
//        return base.ToString();
//    }
//}