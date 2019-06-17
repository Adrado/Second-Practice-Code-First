class Building extends Entity
{
    constructor (json)
    {
        super (json)
        if (json)
        {
            this.Code = json.code;
            this.Address = json.address;
        }
        else
        {
            this.Code = "";
            this.Address = "";
        }
    }
}