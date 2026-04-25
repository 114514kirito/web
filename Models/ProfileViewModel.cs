namespace sujiayang.Models;

public class ProfileViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Motto { get; set; } = string.Empty;

    public string Introduction { get; set; } = string.Empty;

    public ContactInfo Contact { get; set; } = new();

    public List<EducationItem> EducationHistory { get; set; } = [];

    public List<SkillItem> Skills { get; set; } = [];

    public List<ProjectItem> Projects { get; set; } = [];

    public ContactFormModel ContactForm { get; set; } = new();
}

public class ContactInfo
{
    public string Qq { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string GitHubUrl { get; set; } = string.Empty;
}

public class EducationItem
{
    public string TimePeriod { get; set; } = string.Empty;

    public string School { get; set; } = string.Empty;

    public string Major { get; set; } = string.Empty;
}

public class SkillItem
{
    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

public class ProjectItem
{
    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<string> Highlights { get; set; } = [];
}
