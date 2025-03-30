namespace ConteneryAPBD;

public class RefrigeratedContainer : Container {
    private static readonly Dictionary<ProductName, double> ProductTemperatures = new() {
        { ProductName.Bananas, 13.0 },
        { ProductName.Chocolate, 18.0 },
        { ProductName.Fish, -2.0 },
        { ProductName.Meat, -5.0 },
        { ProductName.IceCream, -20.0 },
        { ProductName.FrozenPizza, -30 },
        { ProductName.Cheese, 7.2 },
        { ProductName.Sausages, 5 },
        { ProductName.Butter, 20.5 },
        { ProductName.Eggs, 19 }
    };

    public ProductName StoredGoods { get; }
    public double Temperature { get; }

    public RefrigeratedContainer(double maxLoad, ProductName storedGoods)
        : base("R", maxLoad, false) {
        StoredGoods = storedGoods;
        Temperature = ProductTemperatures[storedGoods];
    }

    public override string ToString() {
        return base.ToString() + $" | Produkt: {StoredGoods}, Temperatura: {Temperature}°C";
    }
}