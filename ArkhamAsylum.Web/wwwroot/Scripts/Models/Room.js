class Room extends Entity
{
    constructor(json)
    {
        super(json);
        if (json)
        {
            this.Number = json.number;
            this.FloorId = json.floorId;
            this.AreaId = json.areaId;
        }
        else
        {
            this.Number = 0;
            this.FloorId = "00000000-0000-0000-0000-000000000000";
            this.AreaId = "00000000-0000-0000-0000-000000000000";
        }
    }
}