﻿class BuildingsViewModel
{
    constructor($http)
    {
        this.Buildings = [];
        this.Http = $http;
        this.GridOptions = null;
        this.InitializeTable();
        this.SelectedBuilding = null;
        this.GetAllBuildings();
        this.IsEditing = false;
    }

    InitializeTable()
    {
        this.GridOptions =
            {
                enableFiltering: false,
                data: 'vm.Buildings',
                appScopeProvider: this,
                columnDefs: [
                    { name: 'Code', field: 'Code' },
                    { name: 'Address', field: 'Address' },
                    { name: '', field: 'Id', cellTemplate: '<input type="button" value="Edit" ng-click="grid.appScope.Select(row.entity)">' },
                    { name: ' ', field: 'Id', cellTemplate: '<input type="button" value="Remove" ng-click="grid.appScope.RemoveBuilding(row.entity)">' }
                ]
            };
    }

    GetAllBuildings()
    {
        this.Http.get("api/buildings")
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        this.Buildings.length = 0;
        for (let i in response.data)
        {
            let building = new Building(response.data[i]);
            this.Buildings.push(building);
        }
        console.log(response)
    }

    CheckFormAdd(complete)
    {
        if (complete)
        {
            this.AddNewBuilding()
        }
    }

    AddNewBuilding()
    {
        let building = new Building();
        building.Code = this.Code;
        building.Address = this.Address;
        this.SetData(building);
    }

    SetData(building)
    {
        this.Http.post("api/buildings", building)
            .then((response) =>
            {
                this.OnSuccesPost(response);
            },
                response => console.log(response)
            );
    }

    OnSuccesPost(response)
    {
        let building = new Building(response.data)
        this.Buildings.push(building);
        this.Clean();
    }

    Clean()
    {
        this.Code = "";
        this.Address = "";
 
    }

    Select(building)
    {
        this.SelectedBuilding = building;
        this.Code = building.Code;
        this.Address = building.Address;
        this.IsEditing = true;

    }

    CheckFormSave(complete)
    {
        if (complete)
        {
            this.SaveSelectedBuilding()
        }
    }

    SaveSelectedBuilding()
    {
        this.SelectedBuilding.Code = this.Code;
        this.SelectedBuilding.Address = this.Address;

        this.SaveEditBuilding();

        this.IsEditing = false;
    }

    SaveEditBuilding()
    {
        let url = "api/buildings/" + this.SelectedBuilding.Id;
        this.Http.put(url, JSON.stringify(this.SelectedBuilding))
            .then((response) =>
            {
                this.OnSuccesEdit(response);
            },
                response => console.log(response)
            );
    }

    OnSuccesEdit(response)
    {
        let building = new Building(response.data)
        let index = this.Buildings.findIndex(x => x.Id == this.SelectedBuilding.Id);
        this.Buildings[index] = building;
        this.SelectedBuilding = null;
        this.Clean();
    }

    RemoveBuilding(building)
    {
        let url = "api/buildings/" + building.Id;
        this.Http.delete(url)
            .then((response) =>
            {
                this.OnSuccesRemove(building);
            },
                response => console.log(response)
            );
    }

    OnSuccesRemove(building)
    {
        let index = this.Buildings.findIndex(x => x.Id == building.Id);
        this.Buildings.splice(index, 1);
        this.Clean();
    }
}

app.component('buildings',
{
    templateUrl: './Scripts/Views/Buildings/BuildingsView.html',
    controller: BuildingsViewModel,
    controllerAs: "vm"
    });




