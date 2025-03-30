namespace ConteneryAPBD;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double maxLoad, bool isHazardous, double height, double depth, double ownWeight)
        : base("L", maxLoad, isHazardous, height, depth, ownWeight) { }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"ALERT [{SerialNumber}]: {message}");
    }

    public override void LoadCargo(double weight)
    {
        double maxAllowedLoad = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (weight > maxAllowedLoad)
        {
            NotifyHazard("Próba załadowania niebezpiecznej ilości płynów!");
            return;
        }
        base.LoadCargo(weight);
    }
}
