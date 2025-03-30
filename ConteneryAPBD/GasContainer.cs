namespace ConteneryAPBD;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double maxLoad, bool isHazardous, double height, double depth, double ownWeight)
        : base("G", maxLoad, isHazardous, height, depth, ownWeight) { }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"ALERT [{SerialNumber}]: {message}");
    }

    public override void LoadCargo(double weight)
    {
        double maxAllowedLoad = MaxLoad * 0.8;
        if (weight > maxAllowedLoad)
            NotifyHazard("Próba załadowania zbyt dużej ilości gazu!");
        base.LoadCargo(weight);
    }
}
