using ContractReceiver.Domain.Contracts;
using ContractReceiver.Domain.Shared.Entities;

namespace ContractReceiver.Domain.Offers.Entities;

public class Content
{
    public string Language { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public string Text { get; private set; } = string.Empty;

    private Content(
        string language,
        string name,
        string title,
        string text)
    {
        Language = language;
        Name = name;
        Title = title;
        Text = text;
    }

    public static Result<Content> Create(
        dynamic language,
        dynamic name,
        dynamic title,
        dynamic text)
    {
        if (language == null)
        {
            return Result.Failure<Content>(ContractErrors.RequiredAttribute(nameof(Language)));
        }

        if (name == null)
        {
            return Result.Failure<Content>(ContractErrors.RequiredAttribute(nameof(Name)));
        }

        if (title == null)
        {
            return Result.Failure<Content>(ContractErrors.RequiredAttribute(nameof(Title)));
        }

        var result = new Content(
            (string)language,
            (string)name,
            (string)title,
            (string)text);

        return result;
    }
}
