namespace PersonalBrand.Domain.Entities;

public class Projects
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Project_Name { get; set; }
    public string Duration { get; set; }
    public int Lessons { get; set; }
    public string Offers { get; set; }
    public string Price { get; set; }
    public string Nutshell { get; set; }
    public int Rate { get; set; }
    public float Students { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public string Link { get; set; }
    public string Poster { get; set; }
}