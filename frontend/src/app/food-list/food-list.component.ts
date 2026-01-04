import { Component } from "@angular/core";
import { Food, foods } from "../food";
@Component({
    selector: 'fp-food-list',
    templateUrl: './food-list.component.html',
    styleUrl: './food-list.component.scss'
})
export class FoodListComponent {
    foods: Food[] = foods;

    share() {
        window.alert("Some product 's been shared!");
    }

    onNotify(food: Food) {
        window.alert(`You will be notified when the ${food.name} goes on sale`);
    }
}