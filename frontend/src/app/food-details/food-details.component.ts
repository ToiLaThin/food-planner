import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Food, foods } from "../food";

@Component({
    selector: "fp-food-details",
    templateUrl: "./food-details.component.html",
    styleUrls: ["./food-details.component.scss"]
})
export class FoodDetailsComponent implements OnInit {
    food: Food | undefined;

    //contains info about the route, such as the food id
    constructor(private route: ActivatedRoute) {}

    ngOnInit(): void {
        const routeParams = this.route.snapshot.paramMap;
        const foodIdFromRoute = Number(routeParams.get("foodId"));
        this.food = foods.find(p => p.id == foodIdFromRoute);
    }

}