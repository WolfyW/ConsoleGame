using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    enum WeaponType
    {
        None,
        Fist,
        Stick,
        Club,
        Spear,
        Saber
    }

    class Weapon
    {
        const int fistDmg = 2;
        const int stickDmg = 16;
        const int clubDmg = 24;
        const int spearDmg = 32;
        const int saberDmg = 40;

        public WeaponType Type { get; private set; }
        public int Damage { get; private set; }

        public Weapon(WeaponType type)
        {
            Type = type;
            InitData();
        }

        public Weapon(char weapon)
        {
            Type = GetTypeFromChar(weapon);
            InitData();
        }

        private WeaponType GetTypeFromChar(char weapon)
        {
            WeaponType type = WeaponType.Fist;
            if (weapon == Symbols.clubMapChar)
            {
                type = WeaponType.Club;
            }
            else if (weapon == Symbols.stickMapChar)
            {
                type = WeaponType.Stick;
            }
            else if (weapon == Symbols.spearMapChar)
            {
                type = WeaponType.Spear;
            }
            else if (weapon == Symbols.saberMapChar)
            {
                type = WeaponType.Saber;
            }
            return type;
        }

        private void InitData()
        {
            switch (Type)
            {
                case WeaponType.Fist:
                    Damage = fistDmg;
                    break;
                case WeaponType.Stick:
                    Damage = stickDmg;
                    break;
                case WeaponType.Club:
                    Damage = clubDmg;
                    break;
                case WeaponType.Spear:
                    Damage = spearDmg;
                    break;
                case WeaponType.Saber:
                    Damage = saberDmg;
                    break;
            }
        }
    }
}
