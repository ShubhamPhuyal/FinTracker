using System.Text.Json;
using FinTracker.Models;
using FinTracker.Services.Interface;

namespace FinTracker.Services
{
    public class TagService : ITagService
    {
        private static readonly string AppTagFilePath = Const.Const.TagsFilePath();
        private List<Tag> _tags;

        public TagService()
        {
            // Initialize tags list
            _tags = LoadTagsFromFile(AppTagFilePath);
        }

        // Fetches all tags
        public async Task<List<Tag>> GetAllTags()
        {
            return await Task.FromResult(_tags);
        }

        // Adds a new tag
        public async Task AddTag(Tag tag)
        {
            tag.Id = _tags.Count > 0 ? _tags.Max(t => t.Id) + 1 : 1; // Assign a unique ID
            _tags.Add(tag);
            await SaveTagsToFile();
        }

        // Updates an existing tag
        public async Task UpdateTag(Tag tag)
        {
            var existingTag = _tags.FirstOrDefault(t => t.Id == tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.Description = tag.Description;

                await SaveTagsToFile();
            }
        }

        // Deletes a tag by its ID
        public async Task DeleteTag(int tagId)
        {
            var tagToRemove = _tags.FirstOrDefault(t => t.Id == tagId);
            if (tagToRemove != null)
            {
                _tags.Remove(tagToRemove);
                await SaveTagsToFile();
            }
        }

        // Retrieves a specific tag by its ID
        public async Task<Tag> GetTagById(int tagId)
        {
            var tag = _tags.FirstOrDefault(t => t.Id == tagId);
            return await Task.FromResult(tag);
        }

        // Private method to load tags from the file
        private List<Tag> LoadTagsFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Tag file not found: {filePath}");
                    return new List<Tag>();
                }

                var json = File.ReadAllText(filePath);
                var tags = JsonSerializer.Deserialize<List<Tag>>(json);

                return tags ?? new List<Tag>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON error: {jsonEx.Message}");
                return new List<Tag>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tags: {ex.Message}");
                return new List<Tag>();
            }
        }

        // Private method to save tags to the file
        private async Task SaveTagsToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(_tags, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(AppTagFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tags: {ex.Message}");
            }
        }
    }
}
