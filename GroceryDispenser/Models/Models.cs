namespace GroceryDispenser.Models;

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    
}

public class GroceryItemDetails
{
    public long? EAN { get; set; }
    public string? Category { get; set; }
    public float WaterConsumedPerPiece { get; set; }
    public float MassPerPieceInGram { get; set; }
}

public class GroceryItem
{
    public string? Name { get; set; }
    public GroceryItemDetails? Details { get; set; }
}

