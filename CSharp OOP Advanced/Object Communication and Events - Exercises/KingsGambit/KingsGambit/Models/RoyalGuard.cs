﻿public class RoyalGuard : Soldier
{
    private const int InitialHealth = 1;

    public RoyalGuard(string name)
        : base(name, InitialHealth)
    {
    }

    public override void KingUnderAttack()
    {
        System.Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}