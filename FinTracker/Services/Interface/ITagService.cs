using FinTracker.Models;

namespace FinTracker.Services.Interface
{
    public interface ITagService
    {
        // Fetches all tags from the data source
        Task<List<Tag>> GetAllTags();

        // Adds a new tag to the data source
        Task AddTag(Tag tag);

        // Updates an existing tag in the data source
        Task UpdateTag(Tag tag);

        // Deletes a tag from the data source using its ID
        Task DeleteTag(int tagId);

        // Retrieves a specific tag by its ID
        Task<Tag> GetTagById(int tagId);
    }
}