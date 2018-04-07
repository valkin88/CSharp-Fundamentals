namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;
    using InfernoInfinity.Core.Attributes;
    using System.Collections.Generic;

    public class Create : Command
    {
        [Inject]
        private IWeaponFactory weaponFactory;

        [Inject]
        private List<IWeapon> createdWeapons;

        public Create(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            IWeapon weapon = this.weaponFactory.CreateWeapon(this.Data);
            createdWeapons.Add(weapon);
        }
    }
}
