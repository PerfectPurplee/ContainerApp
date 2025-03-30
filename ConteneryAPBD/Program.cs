namespace ConteneryAPBD;

internal static class Program
{
    private static void Main()
    {
        var ship = new ContainerShip("Statek 1", 10, 50000);
        var container1 = new LiquidContainer(2000, true, 250, 300, 500);
        var container2 = new LiquidContainer(3000, false, 260, 320, 550);
        var container3 = new GasContainer(5000, true, 270, 330, 600);
        var container4 = new RefrigeratedContainer(4000, ProductName.Bananas, 280, 340, 650);
        
        ship.AddContainer(container1);
        ship.AddContainer(container2);
        ship.AddContainer(container3);
        ship.AddContainer(container4);
        
        container1.LoadCargo(1000);
        container2.LoadCargo(2500);
        container3.LoadCargo(3500);
        container4.LoadCargo(3000);

        ship.PrintShipStatus();

        Console.WriteLine("Usuwanie kontenera...");
        ship.RemoveContainer(container2.SerialNumber);
        ship.PrintShipStatus();
    }
}
