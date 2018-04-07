namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Core.Attributes;

    public class Remove : Command
    {
        [Inject]
        private readonly IWeaponStorage weaponStorage;

        public Remove(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string weaponName = this.Data[1];
            int socketIndex = int.Parse(this.Data[2]);

            weaponStorage.Remove(weaponName, socketIndex);
        }
    }
}
