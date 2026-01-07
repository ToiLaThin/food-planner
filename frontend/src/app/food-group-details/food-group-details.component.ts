import { Component, EventEmitter, Input, Output } from "@angular/core";
import { FoodGroup } from "../food";

@Component({
    selector: "fp-food-group-details",
    templateUrl: "./food-group-details.component.html",
    styleUrls: ["./food-group-details.component.scss"]
})
export class FoodGroupDetailsComponent {
    @Input() foodGroup: FoodGroup | undefined;
    @Output() deleteNotify = new EventEmitter<FoodGroup>();
    @Output() editNotify = new EventEmitter<FoodGroup>();
}