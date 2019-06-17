class Record extends Entity
{
    constructor(json)
    {
        super(json);
        if (json)
        {
            this.Code = json.code;
            this.PatiendId = json.patientId;
            this.BedId = json.bedId;
            this.DiagnosisId = diagnosisId;
        }
        else
        {
            this.Code = "";
            this.PatiendId = "00000000-0000-0000-0000-000000000000";
            this.BedId = "00000000-0000-0000-0000-000000000000";
            this.DiagnosisId = "00000000-0000-0000-0000-000000000000";
        }
    }
}