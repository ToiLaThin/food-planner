import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { FoodGroup } from "../food";

@Injectable({ providedIn: 'root' })
export class FoodGroupService {
    constructor(private httpClient: HttpClient) {}

    addFoodGroup(foodGroup: FoodGroup) {
        return this.httpClient.post(`${environment.apiUrl}/api/v1/food-groups`, foodGroup);
    }

    getFoodGroupList() {
        return this.httpClient.get<FoodGroup[]>(`${environment.apiUrl}/api/v1/food-groups`);
    }
}