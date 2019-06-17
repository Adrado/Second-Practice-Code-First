class Floor extends Entity
{
    constructor(json)
    {
        super(json);
        if (json)
        {
            this.Number = json.number;
            this.BuildingId = json.buildingId;
        }
        else
        {
            this.Number = "";
            this.BuildingId = "00000000-0000-0000-0000-000000000000";
        }
    }
}