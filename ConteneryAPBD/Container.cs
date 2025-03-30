namespace ConteneryAPBD;

public abstract class Container
{
    private static int counter = 1;
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    public double CurrentLoad { get; private set; }
    public bool IsHazardous { get; }
    public double Height { get; }
    public double Depth { get; }
    public double OwnWeight { get; }

    protected Container(string type, double maxLoad, bool isHazardous, double height, double depth, double ownWeight)
    {
        SerialNumber = $"KON-{type}-{counter++}";
        MaxLoad = maxLoad;
        IsHazardous = isHazardous;
        Height = height;
        Depth = depth;
        OwnWeight = ownWeight;
    }

    public virtual void LoadCargo(double weight)
    {
        if (weight > MaxLoad)
            throw new Exception("OverfillException: Przekroczono maksymalną ładowność kontenera!");
        CurrentLoad = weight;
    }

    public virtual void UnloadCargo()
    {
        CurrentLoad = 0;
    }

    public override string ToString()
    {
        return $"[{SerialNumber}] Obciążenie: {CurrentLoad}/{MaxLoad} kg, Wysokość: {Height} cm, Głębokość: {Depth} cm, Waga własna: {OwnWeight} kg";
    }
}
