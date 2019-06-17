class Diagnosis extends Entity
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Code = json.code;
            this.DoctorId = json.doctorId;
            this.RecordId = json.recordId;
        }
        else
        {
            this.Code = "";
            this.DoctorId = "00000000-0000-0000-0000-000000000000";
            this.RecordId = "00000000-0000-0000-0000-000000000000";
        }
    }
}