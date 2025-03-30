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
        if (Containers.Count >= MaxContainers || GetTotalWeight() + container.OwnWeight > MaxWeight)
        {
            Console.WriteLine("Nie można dodać kontenera - przekroczone limity statku.");
            return false;
        }
        Containers.Add(container);
        return true;
    }

    public bool AddContainers(List<Container> containers) {
        return containers.All(container => AddContainer(container));
    }

    public bool RemoveContainer(string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            return true;
        }
        return false;
    }

    public bool ReplaceContainer(string serialNumber, Container newContainer) {
        return RemoveContainer(serialNumber) && AddContainer(newContainer);
    }

    public bool TransferContainer(ContainerShip targetShip, string serialNumber)
    {
        var container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null && targetShip.AddContainer(container))
        {
            Containers.Remove(container);
            return true;
        }
        return false;
    }

    public double GetTotalWeight() {
        return Containers.Sum(container => container.OwnWeight + container.CurrentLoad);
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