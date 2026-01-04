import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Food } from '../food';

@Component({
  selector: 'fp-food-alerts',
  templateUrl: './food-alerts.component.html',
  styleUrl: './food-alerts.component.scss',
})
export class FoodAlertsComponent {
  @Input() food: Food | undefined;
  @Output() notify = new EventEmitter<Food>();
}
