public interface IWareHouse
{
    void EquipArmy(IArmy army);
    bool TryEquipSoldier(ISoldier soldier);
    void AddAmmunition(string name, int number);
}