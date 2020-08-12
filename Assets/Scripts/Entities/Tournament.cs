using System;

[Serializable]
public class Tournament
{
    public string type;
    public string id;
    public Attribute attributes;

    [Serializable]
    public class Attribute
    {
        public string createdAt;
    }
}