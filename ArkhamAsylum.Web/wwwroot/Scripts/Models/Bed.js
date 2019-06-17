class Bed extends Entity
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Code = json.code;
            this.RoomId = json.roomId;
        }
        else
        {
            this.Code = "";
            this.RoomId = "00000000-0000-0000-0000-000000000000"
        }
    }
}