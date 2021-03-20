namespace Assets.Code.Player
{
    public interface IWeaponContainer
    {
        bool IsWeapon { get; }

        string Name { get; }
        int Count { get; }
    }
}