import { Component } from "@angular/core";
import { Food, foods } from "../food";
@Component({
    selector: 'fp-food-list',
    templateUrl: './food-list.component.html',
    styleUrl: './food-list.component.scss'
})
export class FoodListComponent {
    foods: Food[] = foods;
}