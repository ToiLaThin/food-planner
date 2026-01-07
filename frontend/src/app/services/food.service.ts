import { Injectable } from "@angular/core";
import { Food } from "../food";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";

interface FoodPaginateCommand {
    page: number;
    step: number;
    search: string;
}

@Injectable({ providedIn: 'root' })
export class FoodService {
    // paginatedFoods: Food[] = [];
    
    constructor(private http: HttpClient) {}

    getFoodPaginated() {
        return this.http.get<Food[]>(`${environment.apiUrl}/api/v1/foods`);
    }
}