namespace Assets.Code.Player
{
    public interface IWeaponStorage
    {
        void AddWeapon(string name, IWeapon weapon);

        void AddCartridges(string name, int count);

        void DiscardWeapon(string name);

        void DiscardCartridges(string name);
        void AddWeapon(IWeaponContainer deviceController);
    }
}