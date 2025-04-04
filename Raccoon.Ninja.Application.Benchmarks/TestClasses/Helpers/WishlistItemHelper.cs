using Raccoon.Ninja.Application.Benchmarks.TestClasses.Entities.Records;

namespace Raccoon.Ninja.Application.Benchmarks.TestClasses.Helpers;

public static class WishlistItemHelper
{
  private static readonly DateTime Now = DateTime.UtcNow;

  public static WishlistItem FilterWishListItems(WishlistItem wishlistItem,
    List<WishlistItemUserType> allowedUserTypes)
  {
    var isActive = wishlistItem.IsEnabled && wishlistItem.StartDate <= Now &&
      wishlistItem.EndDate >= Now;
    
    return allowedUserTypes.Contains(wishlistItem.UserType) && isActive
      ? wishlistItem
      : null;
  }
}