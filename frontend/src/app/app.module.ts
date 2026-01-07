import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { FoodListComponent } from "./food-list/food-list.component";
import { AppComponent } from "./app.component";
import { TopBarComponent } from "./core/top-bar.component";
import { FoodAlertsComponent } from "./food-alerts/food-alerts.component";
import { FoodDetailsComponent } from "./food-details/food-details.component";
import { HttpClientModule } from "@angular/common/http";
import { FoodGroupListComponent } from "./food-group-list/food-group-list.component";
import { ReactiveFormsModule } from "@angular/forms";
import { FoodGroupNewComponent } from "./food-group-new/food-group-new.component";

@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: 'foods', component: FoodListComponent },
            { path: 'foods/:foodId', component: FoodDetailsComponent },
            { path: 'food-groups', component: FoodGroupListComponent },
            { path: 'food-groups/new', component: FoodGroupNewComponent },

        ])
    ],
    declarations: [
        AppComponent,
        TopBarComponent,
        FoodListComponent,
        FoodAlertsComponent, 
        FoodDetailsComponent,
        FoodGroupListComponent,
        FoodGroupNewComponent
    ],
    bootstrap: [
        AppComponent
    ]
    
})
export class AppModule {}