import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { FoodListComponent } from "./food-list/food-list.component";
import { AppComponent } from "./app.component";
import { TopBarComponent } from "./core/top-bar.component";
import { FoodAlertsComponent } from "./food-alerts/food-alerts.component";
import { FoodDetailsComponent } from "./food-details/food-details.component";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', component: FoodListComponent },
            { path: 'foods/:foodId', component: FoodDetailsComponent }
        ])
    ],
    declarations: [
        AppComponent,
        TopBarComponent,
        FoodListComponent,
        FoodAlertsComponent, 
        FoodDetailsComponent
    ],
    bootstrap: [
        AppComponent
    ]
    
})
export class AppModule {}