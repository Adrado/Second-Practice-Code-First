class Area extends Entity
{
    constructor(json)
    {
        super(json);
        if (json)
        {
            this.Name = json.name;
        }
        else
        {
            this.Name = ""
        }
    }
}