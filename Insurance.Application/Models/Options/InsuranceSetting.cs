namespace Insurance.Application.Models.Options;

public class InsuranceSetting
{
    public Coverage Coverage { get; set; } = null!;
}

public class Coverage
{
    public Surgery Surgery { get; set; } = null!;
    public Dentistry Dentistry { get; set; } = null!;
    public Confinement Confinement { get; set; } = null!;
}

public class Surgery
{
    public int MinAmount { get; set; }
    public int MaxAmount { get; set; }
}

public class Dentistry
{
    public int MinAmount { get; set; }
    public int MaxAmount { get; set; }
}

public class Confinement
{
    public int MinAmount { get; set; }
    public int MaxAmount { get; set; }
}
