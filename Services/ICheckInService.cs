using ITCS_3112_Final_Project.Domain;
using ITCS_3112_Final_Project.Strategies;

namespace ITCS_3112_Final_Project.Services;

public interface ICheckInService
{
    /// <summary>
    /// Finds a member using a specified search strategy.
    /// </summary>
    /// <param name="strategy">The strategy used to locate the member.</param>
    /// <param name="value">The value used in the search.</param>
    /// <returns>
    /// The matching member if found; otherwise null.
    /// </returns>
    Member? FindMember(SearchStrategy strategy, string value);
    
    /// <summary>
    /// Checks in a member using a specified search strategy.
    /// </summary>
    /// <param name="strategy">The strategy used to locate the member.</param>
    /// <param name="value">The value used in the search.</param>
    /// <returns>
    /// True if the member was successfully checked in; otherwise false.
    /// </returns>
    bool CheckInMember(SearchStrategy strategy, string value);
    
    /// <summary>
    /// Checks out a member using a specified search strategy.
    /// </summary>
    /// <param name="strategy">The strategy used to locate the member.</param>
    /// <param name="value">The value used in the search.</param>
    /// <returns>
    /// True if the member was successfully checked out; otherwise false.
    /// </returns>
    bool CheckOutMember(SearchStrategy strategy, string value);
    
    /// <summary>
    /// Determines whether a member is currently checked in.
    /// </summary>
    /// <param name="member">The member to check.</param>
    /// <returns>
    /// True if the member is currently checked in; otherwise false.
    /// </returns>
    bool IsCheckedIn(Member member);
}