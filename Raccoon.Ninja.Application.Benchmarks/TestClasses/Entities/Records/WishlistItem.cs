namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

public record WishlistItem
{
  public bool IsEnabled { get; set; }
  public Guid ProductId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public WishlistItemUserType UserType { get; set; }
}

public enum WishlistItemUserType
{
  Normal = 1,
  Premium = 2,
  Business = 3
}