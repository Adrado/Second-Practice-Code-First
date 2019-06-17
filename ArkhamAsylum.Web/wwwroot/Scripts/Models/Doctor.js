class Doctor extends Entity
{
    constructor (json)
    {
        super (json)
        if (json)
        {
            this.Name = json.name;
            this.FirstSurname = json.firstSurname;
            this.SecondSurname = json.secondSurname;
            this.AreaId = json.areaId;
        }
        else
        {
            this.Name = "";
            this.FirstSurname = "";
            this.SecondSurname = "";
            this.AreaId = "00000000-0000-0000-0000-000000000000";
        }
    }
}