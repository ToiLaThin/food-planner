import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { FoodGroup } from "../food";
import { BehaviorSubject, tap } from "rxjs";

@Injectable({ providedIn: 'root' })
export class FoodGroupService {
    private _foodGroups = new BehaviorSubject<FoodGroup[]>([]);
    public foodGroups$ = this._foodGroups.asObservable();
    
    constructor(private httpClient: HttpClient) {}

    addFoodGroup(foodGroup: FoodGroup) {
        return this.httpClient.post(`${environment.apiUrl}/api/v1/food-groups`, foodGroup);
    }

    getFoodGroupList() {
        return this.httpClient.get<FoodGroup[]>(`${environment.apiUrl}/api/v1/food-groups`).pipe(
            tap(foodGroups => this._foodGroups.next(foodGroups))
        );
    }

    editFoodGroup(foodGroup: FoodGroup) {
        return this.httpClient.put(`${environment.apiUrl}/api/v1/food-groups/${foodGroup.id}/edit`, foodGroup);
    }

    deleteFoodGroup(foodGroup: FoodGroup) {
        return this.httpClient.delete(`${environment.apiUrl}/api/v1/food-groups/${foodGroup.id}/delete`).pipe(
            tap(_ => {
                const nextFoodGroups = this._foodGroups.value.filter(x => x.id != foodGroup.id);
                this._foodGroups.next(nextFoodGroups);
            })
        );
    }
}