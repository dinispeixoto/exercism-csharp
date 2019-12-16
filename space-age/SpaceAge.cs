public struct OrbitalPeriodInEarthYears {
    public const double EARTH = 1;
    public const double MERCURY = 0.2408467;
    public const double VENUS = 0.61519726;
    public const double MARS = 1.8808158;
    public const double JUPITER = 11.862615;
    public const double SATURN = 29.447498;
    public const double URANUS = 84.016846;
    public const double NEPTUNE = 164.79132;
}

public class SpaceAge
{
    public double seconds { get; set; }

    public SpaceAge(int seconds)
    {
        const double earth_orbital_period_in_seconds = 31557600;
        this.seconds = seconds/earth_orbital_period_in_seconds;
    }

    public double OnEarth() => OnPlanet(OrbitalPeriodInEarthYears.EARTH);
    public double OnMercury() => OnPlanet(OrbitalPeriodInEarthYears.MERCURY);
    public double OnVenus() => OnPlanet(OrbitalPeriodInEarthYears.VENUS);
    public double OnMars() => OnPlanet(OrbitalPeriodInEarthYears.MARS);
    public double OnJupiter() => OnPlanet(OrbitalPeriodInEarthYears.JUPITER);
    public double OnSaturn() => OnPlanet(OrbitalPeriodInEarthYears.SATURN);
    public double OnUranus() => OnPlanet(OrbitalPeriodInEarthYears.URANUS);
    public double OnNeptune() => OnPlanet(OrbitalPeriodInEarthYears.NEPTUNE);
    
    private double OnPlanet(double orbital_period_in_earth_years) => this.seconds/orbital_period_in_earth_years;    
}
