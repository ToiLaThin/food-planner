import { Component, OnInit } from "@angular/core";
import { FoodGroupService } from "../services/food-group.service";
import { FoodGroup } from "../food";
import { Observable } from "rxjs";

@Component({
    selector: 'fp-food-group-list',
    templateUrl: './food-group-list.component.html',
    styleUrls: ["food-group-list.component.scss"]
})
export class FoodGroupListComponent implements OnInit {
    constructor(private foodGroupService: FoodGroupService) {}

    ngOnInit(): void {
        this.foodGroupList$ = this.foodGroupService.getFoodGroupList();
    }

    foodGroupList$!: Observable<FoodGroup[]>;


}