namespace ConteneryAPBD;

public class ContainerShip
{
    public string Name { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    private List<Container> Containers { get; }

    public ContainerShip(string name, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public bool AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainers || GetTotalWeight() + container.MaxLoad > MaxWeight)
        {
            Console.WriteLine("Nie można dodać kontenera - przekroczone limity statku.");
            return false;
        }
        Containers.Add(container);
        return true;
    }

    public double GetTotalWeight()
    {
        double weight = 0;
        foreach (var container in Containers)
        {
            weight += container.MaxLoad;
        }
        return weight;
    }

    public void PrintShipStatus()
    {
        Console.WriteLine($"Statek: {Name}, Maksymalna liczba kontenerów: {MaxContainers}, Maksymalna ładowność: {MaxWeight}kg");
        Console.WriteLine("Kontenery:");
        foreach (var container in Containers)
        {
            Console.WriteLine(container);
        }
    }
}