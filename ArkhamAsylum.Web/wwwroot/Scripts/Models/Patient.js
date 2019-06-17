class Patient extends Entity
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Name = json.name;
            this.FirstSurname = json.firsSurname;
            this.SecondSurname = json.secondSurname;
        }
        else
        {
            this.Name = "";
            this.FirstSurname = "";
            this.SecondSurname = "";
        }
    }
}