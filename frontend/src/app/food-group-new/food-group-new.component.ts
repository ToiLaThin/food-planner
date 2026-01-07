import { Component } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { FoodGroupService } from "../services/food-group.service";
import { FoodGroup } from "../food";

@Component({
    selector: 'fp-food-group-new',
    templateUrl: './food-group-new.component.html',
    styleUrls: ["food-group-new.component.scss"]
})
export class FoodGroupNewComponent {
    constructor(
        private formBuilder: FormBuilder, 
        private foodGroupService: FoodGroupService
    ) {}

    foodGroupForm = this.formBuilder.group({
        name: '',
        mainBenefit: ''
    });

    onSubmit() {

        let newFoodGroup: FoodGroup = {
            id: 0,
            name: this.foodGroupForm.controls["name"].value!,
            mainBenefit: this.foodGroupForm.controls["mainBenefit"].value
        }
        debugger;
        this.foodGroupService.addFoodGroup(newFoodGroup).subscribe();
        this.foodGroupForm.reset();
    }
}