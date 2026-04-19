using OrderFlow.Domain.ValueObjects;

namespace OrderFlow.Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public Money Price { get; private set; } = default!;
    public bool IsAvailable { get; private set; } = true;
    public string? ImageUrl { get; private set; }

    private Product() { }

    public Product(string name, decimal price, string? description = null, string? imageUrl = null)
    {
        SetName(name);
        Description = description;
        Price = Money.Create(price);
        IsAvailable = true;
        ImageUrl = imageUrl;
    }

    public void Update(string name, decimal price, string? description = null, string? imageUrl = null)
    {
        SetName(name);
        Description = description;
        Price = Money.Create(price);
        ImageUrl = imageUrl;
        SetUpdated();
    }

    public void Activate() => IsAvailable = true;

    public void Deactivate() => IsAvailable = false;

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Name is required.", nameof(Name));

        Name = name.Trim();
    }
}
