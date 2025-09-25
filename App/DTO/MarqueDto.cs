namespace App.DTO;

public class MarqueDto
{
    public int Id { get; set; }
    public string? Nom { get; set; }
    public int NbProduits { get; set; }

    protected bool Equals(MarqueDto other)
    {
        return Nom == other.Nom && NbProduits == other.NbProduits;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((MarqueDto)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nom, NbProduits);
    }
}
