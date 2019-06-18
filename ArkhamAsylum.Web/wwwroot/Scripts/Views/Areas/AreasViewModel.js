class AreasViewModel
{
    constructor($http)
    {
        this.Areas = [];
        this.Http = $http;
        this.GridOptions = null;
        this.InitializeTable();
        this.SelectedArea = null;
        this.GetAllAreas();
        this.IsEditing = false;
    }

    InitializeTable()
    {
        this.GridOptions =
            {
                enableFiltering: false,
                data: 'vm.Areas',
                appScopeProvider: this,
                columnDefs: [
                    { name: 'Name', field: 'Name' },
                    { name: '', field: 'Id', cellTemplate: '<input type="button" value="Edit" ng-click="grid.appScope.Select(row.entity)">' },
                    { name: ' ', field: 'Id', cellTemplate: '<input type="button" value="Remove" ng-click="grid.appScope.RemoveArea(row.entity)">' }
                ]
            };
    }

    GetAllAreas()
    {
        this.Http.get("api/areas")
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        this.Areas.length = 0;
        for (let i in response.data)
        {
            let area = new Area(response.data[i]);
            this.Areas.push(area);
        }
        console.log(response)
    }

    CheckFormAdd(complete)
    {
        if (complete)
        {
            this.AddNewArea()
        }
    }

    AddNewArea()
    {
        let area = new Area();
        area.Name = this.Name;
        area.Surname = this.Surname;
        area.Email = this.Email;
        area.Password = this.Password;
        area.Address = this.Address;
        this.SetData(area);
    }

    SetData(area)
    {
        this.Http.post("api/areas", area)
            .then((response) =>
            {
                this.OnSuccesPost(response);
            },
                response => console.log(response)
            );
    }

    OnSuccesPost(response)
    {
        let area = new Area(response.data)
        this.Areas.push(area);
        this.Clean();
    }

    Clean()
    {
        this.Name = "";
        this.Surname = "";
        this.Email = "";
        this.Password = "";
        this.Address = "";
    }

    Select(area)
    {
        this.SelectedArea = area;
        this.Name = area.Name;
        this.Surname = area.Surname;
        this.Email = area.Email;
        this.Password = area.Password;
        this.Address = area.Address;
        this.IsEditing = true;

    }

    CheckFormSave(complete)
    {
        if (complete)
        {
            this.SaveSelectedArea()
        }
    }

    SaveSelectedArea()
    {
        this.SelectedArea.Name = this.Name;
        this.SelectedArea.Surname = this.Surname;
        this.SelectedArea.Email = this.Email;
        this.SelectedArea.Password = this.Password;
        this.SelectedArea.Address = this.Address;

        this.SaveEditArea();

        this.IsEditing = false;
    }

    SaveEditArea()
    {
        let url = "api/areas/" + this.SelectedArea.Id;
        this.Http.put(url, JSON.stringify(this.SelectedArea))
            .then((response) =>
            {
                this.OnSuccesEdit(response);
            },
                response => console.log(response)
            );
    }

    OnSuccesEdit(response)
    {
        let area = new Area(response.data)
        let index = this.Areas.findIndex(x => x.Id == this.SelectedArea.Id);
        this.Areas[index] = area;
        this.SelectedArea = null;
        this.Clean();
    }

    RemoveArea(area)
    {
        let url = "api/areas/" + area.Id;
        this.Http.delete(url)
            .then((response) =>
            {
                this.OnSuccesRemove(area);
            },
                response => console.log(response)
            );
    }

    OnSuccesRemove(area)
    {
        let index = this.Areas.findIndex(x => x.Id == area.Id);
        this.Areas.splice(index, 1);
        this.Clean();
    }
}

app.component('areas',
{
    templateUrl: './Scripts/Views/Areas/AreasView.html',
    controller: AreasViewModel,
    controllerAs: "vm"
    });




