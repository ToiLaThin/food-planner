import { Component, OnInit } from "@angular/core";
import { Food } from "../food";
import { FoodService } from "../services/food.service";
import { Observable } from "rxjs";
@Component({
    selector: 'fp-food-list',
    templateUrl: './food-list.component.html',
    styleUrl: './food-list.component.scss'
})
export class FoodListComponent implements OnInit {
    foods$!: Observable<Food[]>;

    constructor(private foodService: FoodService) {}

    ngOnInit(): void {
        this.foods$ = this.foodService.paginatedFoods$;
        this.foodService.getFoodPaginated().subscribe();
    }
    share() {
        window.alert("Some product 's been shared!");
    }

    onNotify(food: Food) {
        window.alert(`You will be notified when the ${food.name} goes on sale`);
    }
}