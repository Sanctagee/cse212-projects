// This file defines the classes needed to deserialize the JSON data
// from the USGS Earthquake API into C# objects.
// The JSON structure is: FeatureCollection -> Features[] -> Properties (place, mag)

public class FeatureCollection
{
    // Maps to the "features" array in the JSON
    public Feature[] Features { get; set; } = [];
}

public class Feature
{
    // Maps to the "properties" object inside each feature
    public FeatureProperties? Properties { get; set; }
}

public class FeatureProperties
{
    // Maps to the "place" field in properties
    public string? Place { get; set; }

    // Maps to the "mag" field in properties
    public double? Mag { get; set; }
}