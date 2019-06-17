class NurseRoomAssignation extends Entity
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Code = json.code;
            this.NurseId = json.nurseId;
            this.RoomId = json.roomId;
        }
        else
        {
            this.Code = "";
            this.NurseId = "00000000-0000-0000-0000-000000000000";
            this.RoomId = "00000000-0000-0000-0000-000000000000";
        }
    }
}