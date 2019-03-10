using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    enum UnitType
    {
        None,
        Hero,
        Org,
        Skeleton
    }

    class Unit
    {
        const int heroHealth = 400;
        const int orgHealth = 60;
        const int skeletonHealth = 80;

        const WeaponType heroWeapon = WeaponType.Fist;
        const WeaponType orgWeapon = WeaponType.Club;
        const WeaponType skeletonWeapon = WeaponType.Saber;

        public UnitType Type { get; private set; }
        public char Symbol { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Health { get; private set; }
        public Weapon Weapon { get; private set; }

        public Unit(char unitSym, int row, int column)
        {
            Row = row;
            Column = column;
            Type = GetUnitFromChar(unitSym);
            InitData();
        }

        private UnitType GetUnitFromChar(char unitSym)
        {
            UnitType type = UnitType.None;
            if (unitSym == Symbols.heroMapSymbol)
            {
                type = UnitType.Hero;
            }
            else if (unitSym == Symbols.orgMapSymbol)
            {
                type = UnitType.Org;
            }
            else if (unitSym == Symbols.skeletonMapSymbol)
            {
                type = UnitType.Skeleton;
            }
            return type;
        }

        private void InitData()
        {
            switch (Type)
            {
                case UnitType.Hero:
                    Weapon = new Weapon(heroWeapon);
                    Health = heroHealth;
                    break;
                case UnitType.Org:
                    Weapon = new Weapon(orgWeapon);
                    Health = orgHealth;
                    break;
                case UnitType.Skeleton:
                    Weapon = new Weapon(skeletonWeapon);
                    Health = skeletonHealth;
                    break;
                default:
                    break;
            }

            Symbol = Symbols.GetMapUnitSymbol(Type);
        }

        public void MoveUnit(ref char carrentSym, ref char nextSym, int row, int column)
        {
            if (Health <= 0)
            {
                return;
            }

            if (nextSym == Symbols.emptySymbol)
            {
                MoveToCell(ref carrentSym, ref nextSym, row, column);
                return;
            }

            if (nextSym == Symbols.heroMapSymbol || nextSym == Symbols.orgMapSymbol || nextSym == Symbols.skeletonMapSymbol)
            {
                Map.GetUnit(row, column, out Unit enemy);
                Attack(enemy);
            }

            if (Type == UnitType.Hero)
            {
                if (nextSym == Symbols.stickMapChar || nextSym == Symbols.clubMapChar || nextSym == Symbols.spearMapChar || nextSym == Symbols.saberMapChar)
                {
                    Weapon = new Weapon(nextSym);
                    MoveToCell(ref carrentSym, ref nextSym, row, column);
                    return;
                }
            }
        }

        private void MoveToCell(ref char carrentSym, ref char nextSym, int row, int column)
        {
            carrentSym = Symbols.emptySymbol;
            nextSym = Symbol;
            Row = row;
            Column = column;
        }

        public void Attack(Unit unit)
        {
            unit.GetDamage(Weapon.Damage);
        }

        public void GetDamage(int dmg)
        {
            Health -= dmg;
            if (Health <= 0)
            {
                Map.LevelData[Row, Column] = Symbols.emptySymbol;
            }
        }
    }
}
