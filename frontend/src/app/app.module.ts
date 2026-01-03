import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { FoodListComponent } from "./food-list/food-list.component";
import { AppComponent } from "./app.component";
import { TopBarComponent } from "./core/top-bar.component";

@NgModule({
    imports: [
        BrowserModule,
        RouterModule.forRoot([
            { path: '', component: FoodListComponent }
        ])
    ],
    declarations: [
        AppComponent,
        TopBarComponent,
        FoodListComponent
    ],
    bootstrap: [
        AppComponent
    ]
    
})
export class AppModule {}