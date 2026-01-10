import { Injectable } from "@angular/core";
import { Food } from "../food";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { BehaviorSubject, map, tap } from "rxjs";

interface FoodPaginateCommand {
    page: number;
    step: number;
    search: string;
}

@Injectable({ providedIn: 'root' })
export class FoodService {
    private _paginatedFoods = new BehaviorSubject<Food[]>([]);
    public paginatedFoods$ = this._paginatedFoods.asObservable();

    constructor(private http: HttpClient) {}

    getFoodPaginated() {
        return this.http.get<Food[]>(`${environment.apiUrl}/api/v1/foods`).pipe(
            tap(foods => this._paginatedFoods.next(foods))
        );
    }
}